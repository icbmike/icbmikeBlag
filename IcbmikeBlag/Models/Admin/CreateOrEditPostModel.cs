using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace IcbmikeBlag.Models.Admin
{
    public class CreateOrEditPostModel : BlagModelBase
    {
        public string Title { get; set; }
        
        public string Content { get; set; }

        [DisplayName("Date Posted")]
        public DateTime DatePosted { get; set; }

        public IEnumerable<string> Tags { get; set; }
        public int? ID { get; set; }
    }
}