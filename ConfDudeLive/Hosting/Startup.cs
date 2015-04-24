using System.Net.Http.Formatting;
using System.Web.Http;
using Owin;
using Swashbuckle.Application;

namespace Hosting
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var httpConfig = new HttpConfiguration();
            httpConfig.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{action}");

            httpConfig.Formatters.Clear();
            httpConfig.Formatters.Add(new JsonMediaTypeFormatter());

            httpConfig
                .EnableSwagger(c => c.SingleApiVersion("v1", "ConfDude Web API"))
                .EnableSwaggerUi();

            app.UseWebApi(httpConfig);
        }
    }
}