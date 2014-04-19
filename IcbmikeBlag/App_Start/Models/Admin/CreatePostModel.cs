using System;
using System.ComponentModel;

namespace IcbmikeBlag.Models.Admin
{
    public class CreatePostModel
    {
        public string Title { get; set; }
        
        public string Content { get; set; }

        [DisplayName("Date Posted")]
        public DateTime DatePosted { get; set; }

        public string Tags { get; set; }
    }
}