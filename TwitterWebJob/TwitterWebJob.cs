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
            
        }

    }

    public class Payload
    {
        int PostID { get; set; }
    }
}
