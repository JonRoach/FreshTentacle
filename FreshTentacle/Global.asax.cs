using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FreshTentacle
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(
                null,   // Dont bother giving this one a name
                "",     // matches the root url
                new { controller = "Products", action = "List", page = 1}   // Defaults
                );

            routes.MapRoute(
                null,
                "Page{page}",   // URL pattern, e.g. ~/Page69
                new { controller = "Products", action = "List" },    // Defaults
                new { page = @"\d+" }   // Constraints: page must be numerical
                );
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory());
        }
    }
}