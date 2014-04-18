﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IcbmikeBlag.Models.Home;

namespace IcbmikeBlag.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            var homeModel = new HomeModel();
            return View(homeModel);
        }
	}
}