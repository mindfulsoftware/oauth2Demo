using Newtonsoft.Json.Serialization;
using OAuth2Demo.ApiClient.Infrastructure;
using System.Web.Http;

namespace OAuth2Demo.ApiClient
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.MapHttpAttributeRoutes();

            config.Filters.Add(new RequireHttpsAttribute());

            config.EnableCors();

            // Web API routes
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
