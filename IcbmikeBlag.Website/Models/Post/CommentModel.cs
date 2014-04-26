using System;
using System.Collections.Generic;

namespace IcbmikeBlag.Models.Post
{
    public class CommentModel
    {
        public string PosterName { get; set; }
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime DatePosted { get; set; }
        public IEnumerable<CommentModel> ChildComments { get; set; }


        public ReplyModel ReplyModel { get; set; }
    }
}