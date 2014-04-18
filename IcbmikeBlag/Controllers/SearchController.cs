using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using IcbmikeBlag.Models.Search;

namespace IcbmikeBlag.Controllers
{
    public class SearchController : Controller
    {
        public ActionResult Index(string searchTerm)
        {
            var searchModel = new SearchModel();
            
            return View(searchModel);
        }
    }
}