using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Web_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
             .UseKestrel()
             .UseContentRoot(Directory.GetCurrentDirectory())
             .UseIISIntegration()
             .UseStartup<Startup>()
             //.UseApplicationInsights()
             .Build();
            host.Run();
            //CreateWebHostBuilder(args).Build().Run();


        }

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>()
        //        .ConfigureAppConfiguration((context, config) =>
        //            {
        //                var env = context.HostingEnvironment;
        //                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
        //                config.AddEnvironmentVariables();
        //                var configuration = config.Build();
        //            })

        //    ;
    }
}