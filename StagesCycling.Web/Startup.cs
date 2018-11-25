using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;

[assembly: OwinStartup(typeof(StagesCycling.Web.Startup))]

namespace StagesCycling.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var physicalFileSystem = new PhysicalFileSystem(@"./www");
            var options = new FileServerOptions
            {
                EnableDefaultFiles = true,
                FileSystem = physicalFileSystem
            };
            options.StaticFileOptions.FileSystem = physicalFileSystem;
            options.StaticFileOptions.ServeUnknownFileTypes = true;
            options.DefaultFilesOptions.DefaultFileNames = new[]
            {
             "index.html"
            };

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigureAuth(app);
        }
    }
}
