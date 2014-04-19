using System;
using IcbmikeBlag.Application.Repositories;

namespace IcbmikeBlag.Application
{
    public class BlogPost : IEntity<int>
    {
        public string Content { get; set; }
        public string Title { get; set; }
        public DateTime DatePosted { get; set; }

        public int Key { get; set; }
    }
}