using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace IcbmikeBlag.Models.Post
{
    public class PostModel : BlagModelBase
    {
        public int ID { get; set; }

        public DateTime DatePosted { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public IEnumerable<string> Tags { get; set; }
        
        public IEnumerable<CommentModel> Comments { get; set; }

        public ReplyModel ReplyModel { get; set; }

    }
}