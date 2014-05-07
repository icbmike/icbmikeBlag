using System.Collections.Generic;
using System.Linq;
using IcbmikeBlag.Application.DAL;
using IcbmikeBlag.Application.Entities;
using Microsoft.WindowsAzure.Jobs;
using IcbmikeBlag.TwitterWebJob;

namespace IcbmikeBlag.Application.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BlagContext _dbContext;

        public BlogPostRepository(BlagContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<BlogPost> GetRecentBlogPosts(int numPosts = 10, int page = 1)
        {
            return _dbContext.BlogPosts
                .OrderByDescending(post => post.DatePosted)
                .Skip((page - 1)*numPosts)
                .Take(numPosts).ToList();
        }

        public void AddPost(BlogPost blogPost)
        {
            _dbContext.BlogPosts.Add(blogPost);
            _dbContext.SaveChanges();

            //
            var jobHost = new JobHost();
            jobHost.Call(typeof(TwitterWebJob.TwitterWebJob).GetMethod("EnqueueBlogPost"), new{postID = blogPost.ID});
        }

        public void UpdatePost(BlogPost blogPost)
        {
            var post = _dbContext.BlogPosts.Find(blogPost.ID);
            
            //Update all the deets
            post.Title = blogPost.Title;
            post.Content = blogPost.Content;
            post.DatePosted = blogPost.DatePosted;

            _dbContext.SaveChanges();
        }

        public BlogPost GetPost(int postID)
        {
            return _dbContext.BlogPosts.Find(postID);
        }

        public Comment GetComment(int commentID)
        {
            return _dbContext.Comments.Find(commentID);
        }

        public void AddComment(IReplyable replyable, Comment comment)
        {
            replyable.ChildComments.Add(comment);
            _dbContext.SaveChanges();
        }

        public IEnumerable<BlogPost> ListBlogPosts()
        {
            return _dbContext.BlogPosts.OrderByDescending(post => post.DatePosted).ToList();
        }
    }
}