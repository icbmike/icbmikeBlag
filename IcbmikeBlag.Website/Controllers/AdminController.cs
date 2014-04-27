using System;
using System.Collections.Generic;
using System.Configuration;
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
            var model = new AdminHubModel()
            {
                StyleToggleModel = new StyleToggleModel()
                {
                    Style = ConfigurationManager.AppSettings["SiteStyle"]
                }
            };
            return View(model);
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
        public ActionResult CreateOrEditPost(int? id)
        {
            CreateOrEditPostModel model;
            
            if (id.HasValue)
            {
                //Retrieve the post what the id is for
                var blogPost = _postRepository.GetPost(id.Value);
                
                //Couldn't find it
                if (blogPost == null)
                {
                    return HttpNotFound("Coudln't find the post with id " + id.Value);
                }
                
                model = new CreateOrEditPostModel()
                {
                    ID = blogPost.ID,
                    DatePosted = blogPost.DatePosted,
                    Content = blogPost.Content,
                    Title = blogPost.Title,
                    Tags = new List<string>{"#hashtag"}
                };
            }
            else
            {
                model = new CreateOrEditPostModel()
                {
                    DatePosted = DateTime.Now.Date
                };
            }
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateOrEditPost(CreateOrEditPostModel model)
        {

            //Create BlogPost to update/save
            var blogPost = new BlogPost()
            {
                Content = model.Content,
                Title = model.Title,
                DatePosted = model.DatePosted
            };

            if (model.ID.HasValue)
            {
                //We were editing a post
                blogPost.ID = model.ID.Value;
                _postRepository.UpdatePost(blogPost);
            }
            else
            {
                //Createing a new one
                _postRepository.AddPost(blogPost);
            }

            //Redirect to home page
            return RedirectToAction("Index", "Posts");
        }

        [Authorize]
        public ActionResult ChangeUser()
        {
            throw new NotImplementedException();
        }

        [Authorize]
        public ActionResult ToggleSiteStyle(StyleToggleModel model)
        {

            ConfigurationManager.AppSettings["SiteStyle"] = model.Style;
            return RedirectToAction("Index");
        }
    }
}