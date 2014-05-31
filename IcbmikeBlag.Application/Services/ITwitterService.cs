using IcbmikeBlag.Application.Entities;

namespace IcbmikeBlag.Application.Services
{
    public interface ITwitterService
    {
        void Post(BlogPost blogPost);
    }
}