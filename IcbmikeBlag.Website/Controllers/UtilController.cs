using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarkdownSharp;

namespace IcbmikeBlag.Controllers
{
    public class UtilController : Controller
    {
        /// <summary>
        /// Transforms markdown to html
        /// </summary>
        /// <returns></returns>
        public ActionResult TransformMarkdown(string markdown)
        {
            var transformer = new Markdown();
            var html = transformer.Transform(markdown);

            return Json(html);
        }
    }
}