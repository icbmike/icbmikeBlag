using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IcbmikeBlag.Application;
using IcbmikeBlag.Models.Home;

namespace IcbmikeBlag.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            var homeModel = new HomeModel()
            {
                Posts = new List<PostModel>(){
                    new PostModel()
                    {
                        Content = new LoremIpsum().GenerateIpsum(5),
                        Title = "First Post",
                        DatePosted = DateTime.Now
                    },
                    new PostModel()
                    {
                        Content = new LoremIpsum().GenerateIpsum(3),
                        Title = "Second Post",
                        DatePosted = DateTime.Now.AddDays(1)
                    }
                
                }.OrderByDescending(model => model.DatePosted)
            };
            return View(homeModel);
        }

    }
}