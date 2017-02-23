//--------------------------------------------------------------------------
// <copyright file="RouteConfig.cs" company="Front Range Systems, LLC">
//     Copyright (c) 2017 Front Range Systems, LLC. All rights reserved.
//     You are free to use this source code as you wish. Front Range Systems, LLC is not
//     responsible for any bugs, errors, or resulting damage from problems
//     with this source code. We are, after all, human. This code is meant
//     to be used as a learning tool. 
// </copyright>
// <author>Matt Dixon</author>
//--------------------------------------------------------------------------

using System.Web.Mvc;
using System.Web.Routing;

namespace FrontRangeSystems.UnitTesting.WebClient
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
