using System.Web.Http;

namespace SignalRMvc
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
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

//            config.Routes.MapHttpRoute(
//                name: "WeatherApi",
//                routeTemplate: "api/{controller}/{service}/{id}",
//                defaults: new { id = RouteParameter.Optional }
//            );

        }
    }
}
