using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Validation.Validators;
using System.Web.Mvc;
using IcbmikeBlag.Application.Entities;
using IcbmikeBlag.Application.Repositories;
using IcbmikeBlag.Models;
using IcbmikeBlag.Models.Post;
using IcbmikeBlag.Models.Search;
using MarkdownSharp;
using WebGrease.Activities;

namespace IcbmikeBlag.Controllers
{
    public class PostsController : Controller
    {
        private readonly IBlogPostRepository _postRepository;

        public PostsController(IBlogPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public ActionResult Index()
        {
            //Create a markdown parser
            var markdown = new Markdown();

            var homeModel = new PostsModel()
            {
                Posts = _postRepository.GetRecentBlogPosts().Select(post => new PostModel()
                {
                    ID = post.ID,
                    Title = post.Title,
                    Content = markdown.Transform(post.Content), 
                    DatePosted = post.DatePosted,
                    Tags = new List<string>(){"#hashtag"}
                })
            };
            return View(homeModel);
        }

        public ActionResult Search(string searchTerm)
        {
            var searchModel = new SearchModel();

            return View(searchModel);
        }

        public ActionResult TaggedWith(string tag)
        {
            throw new NotImplementedException();
        }

        public ActionResult Post(int id)
        {
            var blogPost = _postRepository.GetPost(id);

            //Check if we found something
            if (blogPost == null)
            {
                return HttpNotFound("Blag post with that ID couldn't be found");
            }

            var markdown = new Markdown();

            //Otherwise populate
            var postModel = new PostModel()
            {
                ID = blogPost.ID,
                Content = markdown.Transform(blogPost.Content),
                DatePosted = blogPost.DatePosted,
                Tags = new List<string>{"#hashtag"},
                Title = blogPost.Title,
                ReplyModel = new ReplyModel()
                {
                    ReplyID = blogPost.ID,
                    ReplyingToPost = true,
                    PostID = blogPost.ID
                },
                
                //We need to get the comments, in the future we may need to only load comments to a certain depth
                //However at this stage, I think it is safe to load the entire comment tree
                Comments = ConstructCommentsTree(blogPost.ChildComments, blogPost.ID)
            };

            return View(postModel);
        }

        private IEnumerable<CommentModel> ConstructCommentsTree(IEnumerable<Comment> comments, int rootPostID)
        {
            return comments.Any()
                ? comments.Select(comment => new CommentModel()
                {
                    PosterName =  comment.PosterName,
                    ID = comment.ID,
                    Content = comment.Content,
                    DatePosted = comment.DatePosted,
                    ChildComments = ConstructCommentsTree(comment.ChildComments, rootPostID),
                    ReplyModel = new ReplyModel()
                    {
                        ReplyID = comment.ID,
                        PostID = rootPostID
                    }
            }) 
            : new List<CommentModel>();
        }

        public ActionResult Archive()
        {
            var blogPosts = _postRepository.ListBlogPosts();

            var archiveModel = new ArchiveModel()
            {
                Items = blogPosts.Select(post => new ArchiveItemModel()
                {
                    ID = post.ID,
                    Title = post.Title,
                    DatePosted = post.DatePosted
                })
                
            };

            return View(archiveModel);
        }

        public ActionResult Error()
        {
            var errorModel = new ErrorModel();
            return View("Error", errorModel);
        }

        [HttpPost]
        public ActionResult Reply(ReplyModel model)
        {
            var replyable = model.ReplyingToPost
                ? (IReplyable) _postRepository.GetPost(model.ReplyID) //Safe cast to give the compiler context
                : _postRepository.GetComment(model.ReplyID);


            _postRepository.AddComment(replyable, new Comment()
            {
                PosterName = model.PosterName ?? "Anonymous",
                Content = model.ReplyContent,
                DatePosted = DateTime.Now
            });

            return RedirectToAction("Post", new {id = model.PostID});
        }
    }
}