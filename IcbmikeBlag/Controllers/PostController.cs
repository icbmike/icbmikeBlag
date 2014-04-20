using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using IcbmikeBlag.Application.Repositories;
using IcbmikeBlag.Models.Post;
using IcbmikeBlag.Models.Search;

namespace IcbmikeBlag.Controllers
{
    public class PostController : Controller
    {
        private readonly IBlogPostRepository _postRepository;

        public PostController(IBlogPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        //
        public ActionResult Index()
        {
            var homeModel = new PostsModel()
            {
                Posts = _postRepository.GetRecentBlogPosts().Select(post => new PostModel()
                {
                    ID = post.ID,
                    Title = post.Title,
                    Content = post.Content, // This would be where we would transform markdown
                    DatePosted = post.DatePosted,
                    Tags = new List<string>(){"#hashtag"}
                })
            };
            return View(homeModel);
        }

        public ActionResult Search(string searchTerm)
        {
            var searchModel = new SearchModel();

            return View(searchModel);
        }

        public ActionResult TaggedWith(string tag)
        {
            throw new NotImplementedException();
        }

        public ActionResult Post(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Archive(int? year, int? month, int? day)
        {
            throw new NotImplementedException();
        }
    }
}