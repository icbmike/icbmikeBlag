using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Jobs;

namespace IcbmikeBlag.TwitterWebJob
{
    public class TwitterWebJob
    {
        public static void Main(string[] args)
        {
            JobHost host = new JobHost();
            host.RunAndBlock();
        }

        public static void BlogPostQueue([QueueInput("blogPostQueue")]Payload payload)
        {
            Console.WriteLine(payload.PostID);
        }

        public static void EnqueueBlogPost([QueueOutput("blogPostQueue")] out Payload payload, int postID)
        {
            payload = new Payload()
            {
                PostID = postID;
            };
        }

    }

    public class Payload
    {
        public int PostID { get; set; }
    }
}
