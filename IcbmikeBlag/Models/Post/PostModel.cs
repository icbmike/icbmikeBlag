using System;
using System.Collections;
using System.Collections.Generic;

namespace IcbmikeBlag.Models.Home
{
    public class PostModel
    {
        public int ID { get; set; }

        public DateTime DatePosted { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public IEnumerable<string> Tags { get; set; }
    }
}