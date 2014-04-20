using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using IcbmikeBlag.Application.Entities;
using IcbmikeBlag.Application.Repositories;
using IcbmikeBlag.Models.Admin;

namespace IcbmikeBlag.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBlogPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public AdminController(IBlogPostRepository postRepository, IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(bool hasErrors = false)
        {
            var model = new LoginModel(){HasErrors = hasErrors};
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            var user = _userRepository.GetUser(model.Username, model.Password);
            
            //Credentials werent valid
            if (user == null)
            {
                return RedirectToAction("Login", new {hasErrors = true});
            }

            FormsAuthentication.SetAuthCookie(model.Username, false);
            
            return Redirect(FormsAuthentication.DefaultUrl);

        }

        [Authorize]
        public ActionResult CreatePost()
        {
            var model = new CreatePostModel()
            {
                DatePosted = DateTime.Now.Date
            };
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreatePost(CreatePostModel model)
        {
            _postRepository.AddPost(new BlogPost()
            {
                Content = model.Content,
                Title = model.Title,
                DatePosted = model.DatePosted
            });

            return RedirectToAction("Index", "Home");
        }

        public ActionResult ChangeUser()
        {
            throw new NotImplementedException();
        }
    }
}