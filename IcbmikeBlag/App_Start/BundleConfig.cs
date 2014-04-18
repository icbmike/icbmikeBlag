using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace IcbmikeBlag
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/main_styles").Include(
                "~/Content/Styles/main.css"
                ));

            bundles.Add(new ScriptBundle("~/jquery").Include(
                "~/Content/Scripts/jquery/jquery-1.11.0.js"
                ));

            bundles.Add(new ScriptBundle("~/main_js").Include(
                "~/Content/Scripts/main.js"
                ));
        }
    }
}