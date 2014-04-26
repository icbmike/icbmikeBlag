namespace IcbmikeBlag.Models.Post
{
    public class ReplyModel
    {
        public int ReplyID { get; set; }

        public int PostID { get; set; }

        public string PosterName { get; set; }

        public string ReplyContent { get; set; }

        /// <summary>
        /// Indicates whether this is a reply to a comment or a post
        /// </summary>
        public bool ReplyingToPost { get; set; }
    }
}