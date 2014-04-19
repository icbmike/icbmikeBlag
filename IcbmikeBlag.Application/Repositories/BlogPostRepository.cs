using System.Collections.Generic;
using System.Linq;
using IcbmikeBlag.Application.DAL;
using IcbmikeBlag.Application.Entities;

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
    }
}