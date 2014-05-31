using System;
using IcbmikeBlag.Application.Entities;
using TweetSharp;

namespace IcbmikeBlag.Application.Services
{
    public class TwitterService : ITwitterService
    {
        private readonly ITwitterServiceSettings _serviceSettings;

        public TwitterService(ITwitterServiceSettings serviceSettings)
        {
            _serviceSettings = serviceSettings;
        }

        public void Post(BlogPost blogPost)
        {
            var twitter = new TweetSharp.TwitterService(_serviceSettings.ConsumerKey, _serviceSettings.ConsumerSecret);
            twitter.AuthenticateWith(_serviceSettings.AccessToken, _serviceSettings.AccessTokenSecret);

            twitter.SendTweet(new SendTweetOptions()
            {
                Status = BuildStatus(blogPost)
            }, (status, response) => Console.WriteLine(response.StatusCode));
        }

        private string BuildStatus(BlogPost blogPost)
        {
            //First build the link
            var url = "www.icbmike.com/Posts/Post/" + blogPost.ID;

            var titleAvailableCharacterCount = 140 - url.Length - 1; //1 charachter for the space

            return blogPost.Title.Length <= titleAvailableCharacterCount
                ? blogPost.Title + " " + url
                : blogPost.Title.Substring(0, titleAvailableCharacterCount - 3) + "... " + url;
        }
    }
}