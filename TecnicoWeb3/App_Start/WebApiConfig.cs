
using System.Web.Http;
using System.Web.Http.Cors;

namespace TecnicoWeb3
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web
            config.EnableCors();

            //Ignore JSON Loop
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
            = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
