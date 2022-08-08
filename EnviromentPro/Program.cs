using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnviromentPro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            //.
            //ConfigureAppConfiguration((hostingContext, configurationBuilder) =>
            //{
            //    //var builder = configurationBuilder;
            //    configurationBuilder.Sources.Clear();
            //    configurationBuilder.AddJsonFile("appsettings.json", true, true);
            //    configurationBuilder.AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json");
            //    configurationBuilder.AddEnvironmentVariables();
            //    configurationBuilder.AddJsonFile("testappsettings.json");
            //    if (hostingContext.HostingEnvironment.IsDevelopment())
            //        configurationBuilder.AddUserSecrets<Startup>();
            //})
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
