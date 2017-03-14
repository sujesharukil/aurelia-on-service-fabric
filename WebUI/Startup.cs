using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebUI
{
    public static class Startup
    {
        public static void ConfigureApp(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var fileSystem = new PhysicalFileSystem(@".\public");
            var options = new FileServerOptions
            {
                EnableDefaultFiles = true,
                FileSystem = fileSystem,
                RequestPath = PathString.Empty,
                EnableDirectoryBrowsing = false
            };
            options.DefaultFilesOptions.DefaultFileNames = new[] { "index.html" };
            options.StaticFileOptions.FileSystem = fileSystem;
            options.StaticFileOptions.ServeUnknownFileTypes = true;
            options.EnableDirectoryBrowsing = true;

            config.MapHttpAttributeRoutes();
            appBuilder.UseFileServer(options);

            appBuilder.UseWebApi(config);
        }
    }
}
