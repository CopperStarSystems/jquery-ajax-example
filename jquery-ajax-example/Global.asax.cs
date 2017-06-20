//  --------------------------------------------------------------------------------------
// jquery-ajax-example.Global.asax.cs
// 2017/06/14
//  --------------------------------------------------------------------------------------

using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace jquery_ajax_example
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name 
                "{controller}/{action}/{id}",                           // URL with parameters 
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );
        }
    }
}