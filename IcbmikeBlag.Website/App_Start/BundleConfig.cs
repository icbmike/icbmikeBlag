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
            bundles.Add(new StyleBundle("~/styles/main").Include(
                "~/Content/Styles/lightstyle.css"
                ));

            bundles.Add(new ScriptBundle("~/js/jquery").Include(
                "~/Content/Scripts/jquery/jquery-1.11.0.js",
                "~/Content/Scripts/jquery/jquery.debounce-1.0.5.js"
                ));

            bundles.Add(new ScriptBundle("~/js/main").Include(
                "~/Content/Scripts/main.js"
                ));
        }
    }
}