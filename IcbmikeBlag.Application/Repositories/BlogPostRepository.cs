using System;
using System.Collections.Generic;
using System.Linq;

namespace IcbmikeBlag.Application.Repositories
{
    public class BlogPostRepository : IRepository<int, BlogPost>
    {
        public IEnumerable<BlogPost> GetRecentBlogPosts(int numPosts = 10, int page = 1)
        {
           
        }

        public BlogPost GetBlogPost(int postID)
        {
            throw new NotImplementedException();
        }

        public void SaveBlogPost(BlogPost post)
        {
            throw new NotImplementedException();
        }

        public void DeleteBlogPost(int postID)
        {
            throw new NotImplementedException();
        }
    }
}