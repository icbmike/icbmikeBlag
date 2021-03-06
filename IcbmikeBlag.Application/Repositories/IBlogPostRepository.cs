﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IcbmikeBlag.Application.Entities;

namespace IcbmikeBlag.Application.Repositories
{
    public interface IBlogPostRepository
    {
        IEnumerable<BlogPost> GetRecentBlogPosts(int numPosts = 10, int page = 1);
        
        void AddPost(BlogPost blogPost);

        void UpdatePost(BlogPost blogPost);

        BlogPost GetPost(int postID);

        Comment GetComment(int commentID);
        
        void AddComment(IReplyable replyable, Comment comment);
        
        IEnumerable<BlogPost> ListBlogPosts();
    }
}
