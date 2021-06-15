using Microsoft.Owin;
using Owin;
using SignalRMvc.Constraints;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Routing;

[assembly: OwinStartup(typeof(SignalRMvc.Startup))]

namespace SignalRMvc
{
    public class Startup
    {
        public static HttpConfiguration HttpConfiguration { get; set; } = new HttpConfiguration();

        public void Configuration(IAppBuilder app)
        {
            var config = Startup.HttpConfiguration;
            ConfigureWebApi(app, config);
        }

        private static void ConfigureWebApi(IAppBuilder app, HttpConfiguration config)
        {
            var constraintResolver = new DefaultInlineConstraintResolver();
            constraintResolver.ConstraintMap.Add("identity", typeof(IdConstraint));
            config.MapHttpAttributeRoutes(constraintResolver);

            config.Formatters.XmlFormatter.UseXmlSerializer = true;
            //config.Formatters.JsonFormatter.UseDataContractJsonSerializer = true;

            //app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseWebApi(config);
      
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}
