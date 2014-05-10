using System.ServiceModel.Syndication;
using System.Web.Mvc;
using System.Xml;

namespace IcbmikeBlag
{
    /// <summary>
    /// An action result that repreents an RSS feed
    /// </summary>
    public class RSSResult : ActionResult
    {
        private readonly SyndicationFeed _feed;

        public RSSResult(SyndicationFeed feed)
        {
            _feed = feed;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType= "application/rss+xml";
            
            using (var xmlWriter = XmlWriter.Create(context.HttpContext.Response.OutputStream))
            {
                var rss20FeedFormatter = new Rss20FeedFormatter(_feed);
                rss20FeedFormatter.WriteTo(xmlWriter);
            }
        }

    }
}