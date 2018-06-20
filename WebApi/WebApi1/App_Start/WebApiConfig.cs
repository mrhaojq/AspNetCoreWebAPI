using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApi1.Filter;

namespace WebApi1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //将过滤器添加到WebApiConfig中 不要添加到FilterConfig中 它是给MVC用的
            config.Filters.Add(new APIAuthorizeAttribute());
        }
    }
}
