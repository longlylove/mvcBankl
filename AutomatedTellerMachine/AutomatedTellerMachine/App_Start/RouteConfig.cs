using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AutomatedTellerMachine
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //igonre all resources as handled by a separate hanlder
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            //This route will be called before the default route because of the route order
            //This route is used to retrieve serial number of the ATM
            routes.MapRoute(
                name: "SerialNumber",
                url: "serial",
                defaults: new { controller = "Home", action = "Serial"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            ); 
        }
    }
}
