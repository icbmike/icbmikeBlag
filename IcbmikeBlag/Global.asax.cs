using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using IcbmikeBlag.Application.DAL;
using IcbmikeBlag.Application;

namespace IcbmikeBlag
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DependencyConfig.RegisterDepencies();

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlagContext, Application.Migrations.Configuration>());
        }
    }
}
