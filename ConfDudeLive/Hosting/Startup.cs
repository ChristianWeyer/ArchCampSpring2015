using System.Net.Http.Formatting;
using System.Web.Http;
using Owin;

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

            app.UseWebApi(httpConfig);
        }
    }
}