using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IcbmikeBlag.Application;
using IcbmikeBlag.Application.Repositories;
using IcbmikeBlag.Models.Home;

namespace IcbmikeBlag.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogPostRepository _postRepository;

        public HomeController(IBlogPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        //
        // GET: /Home/
        public ActionResult Index()
        {
            var homeModel = new HomeModel()
            {
                Posts = _postRepository.GetRecentBlogPosts().Select(post => new PostModel()
                {
                    Title = post.Title,
                    Content = post.Content, // This would be where we would transform markdown
                    DatePosted = post.DatePosted
                })
            };
            return View(homeModel);
        }

    }
}