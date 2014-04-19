using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcbmikeBlag.Application.Entities
{
    public class BlogPost
    {
        public int ID { get; set; }

        public string Content { get; set; }
        public DateTime DatePosted { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } 
    }
}
