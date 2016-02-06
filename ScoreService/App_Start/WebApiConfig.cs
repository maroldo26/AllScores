﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ScoreService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{param}",
                defaults: new { param = RouteParameter.Optional }
            );

            config.Filters.Add(new ExceptionFilter());
        }
    }
}
