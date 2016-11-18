using Noteworthy.Models;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Noteworthy
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var context = new ApplicationDbContext();
            context.SysUsers.RemoveRange(context.SysUsers);
            context.Notes.RemoveRange(context.Notes);
            context.Topics.RemoveRange(context.Topics);
            context.SaveChanges();
        }
    }
}
