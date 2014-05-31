using System;
using System.Configuration;

namespace IcbmikeBlag.Application.Services
{
    public class TwitterServiceSettings : ITwitterServiceSettings
    {
        public string ConsumerKey
        {
            get
            {
                return ConfigurationManager.AppSettings["TwitterConsumerKey"] 
                       ?? Environment.GetEnvironmentVariable("TwitterConsumerKey");
            }
        }

        public string ConsumerSecret
        {
            get
            {
                return ConfigurationManager.AppSettings["TwitterConsumerSecret"]
                       ?? Environment.GetEnvironmentVariable("TwitterConsumerSecret");
            }
        }

        public string AccessTokenSecret
        {
            get
            {
                return ConfigurationManager.AppSettings["TwitterAccessTokenSecret"]
                       ?? Environment.GetEnvironmentVariable("TwitterAccessTokenSecret");
            }
        }

        public string AccessToken
        {
            get
            {
                return ConfigurationManager.AppSettings["TwitterAccessToken"]
                       ?? Environment.GetEnvironmentVariable("TwitterAccessToken");
            }
        }
    }
}