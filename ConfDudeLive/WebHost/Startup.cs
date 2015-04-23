using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using Owin;

namespace WebHost
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