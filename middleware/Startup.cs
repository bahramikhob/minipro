using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace middleware
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //در صورت اجرا این پایپ لاین، پایپ لاین های که در زیر این پایپ لاین قرار دارد اجرا نمی شود
            //به چنین پایپ لاین هایی گفته می شود ترمینال پایپ لاین
            //app.Run(async context =>
            // {
            //     await context.Response.WriteAsync("This is Terminator");
            // });


            /*
            app.Use(async (httpcontext, next) =>
            {
              
                await httpcontext.Response.WriteAsync("There is pipe 1\n");
                await next();
                await httpcontext.Response.WriteAsync("There is pipe 2\n");
            });

            app.Use(async (httpcontext, next) =>
            {

                await httpcontext.Response.WriteAsync("There is pipe 3\n");
                await next();

            });
            
            result:
                      There is pipe 1
                      There is pipe 3
                      Hello World!
                      There is pipe 2
             
             */

            //------------------middleware handle Error-----------------------------
            //app.Use(async (context, next) =>
            //{
            //    try
            //    {
            //        await next();
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine("".PadRight(100, '-'));
            //        Console.WriteLine(ex.Message);
            //        Console.WriteLine("".PadRight(100, '-'));

            //        await context.Response.WriteAsync("khataii dar system etefagh oftad");
            //    }
            //});
            //app.Use(async (context, next) =>
            //{
            //    if (context.Request.Query.ContainsKey("ex"))
            //        throw new Exception("Bichare shodim");
            //    await next();
            //});
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //app.Use(async (context, next) =>
            //{
            //    Stopwatch stopwatch = new Stopwatch();
            //    stopwatch.Start();
            //    await next();

            //    stopwatch.Stop();

            //    Console.WriteLine("".PadRight(100, '-'));
            //    await context.Response.WriteAsync($"Total time {stopwatch.ElapsedMilliseconds}\n");
            //    Console.WriteLine($"Total time {stopwatch.ElapsedMilliseconds}");
            //    Console.WriteLine("".PadRight(100, '-'));
            //});
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("First Midd Befor \n");
            //    await next();
            //    await context.Response.WriteAsync("First Midd After \n");
            //  });
          //----------------------------------------------------------------------------------------

            app.UseRouting();

            app.UseMiddleware<LoggerMiddleware>();
            app.useMyMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!\n");
                });
            });


        }
    }
}
