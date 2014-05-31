namespace IcbmikeBlag.Application.Services
{
    public interface ITwitterServiceSettings
    {
        string ConsumerKey { get;  }
        string ConsumerSecret { get;  }
        string AccessTokenSecret { get;  }
        string AccessToken { get;  }
    }
}