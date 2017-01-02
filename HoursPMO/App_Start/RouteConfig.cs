using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HoursPMO
{
    /// <summary>
    /// Routing class
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Class for default and custom routes
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "WeekPerUserPerProjects", action = "MonthReportSelect", id = UrlParameter.Optional }
            );
        }
    }
}
