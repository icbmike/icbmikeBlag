using System.Collections.Generic;

namespace IcbmikeBlag.Models.Post
{
    public class PostsModel : BlagModelBase
    {
        public IEnumerable<PostModel> Posts { get; set; }
    }
}