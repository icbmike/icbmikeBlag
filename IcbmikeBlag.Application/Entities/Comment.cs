using System;
using System.Collections.Generic;

namespace IcbmikeBlag.Application.Entities
{
    public class Comment
    {
        public int ID { get; set; }
        public string PosterName { get; set; }
        public DateTime DatePosted { get; set; }
        public string Content { get; set; }

        public virtual ICollection<Comment> ChildComments { get; set; } 
    }
}