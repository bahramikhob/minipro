using DI.Domain;
using DI.LifeTimes;
using DI.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace DI
{
    public class Startup
    {
        public SettingSite _settingSite { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _settingSite = configuration.GetSection(nameof(SettingSite)).Get<SettingSite>();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<ITransientObject, TransientObject>();
            services.AddScoped<IScopeObject, ScopeObject>();
            services.AddSingleton<ISingletonObject, SingletonObject>();



            services.AddControllersWithViews();
            services.AddDbContext<MyContext>(op=> {
                op.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IPersonRepository, PersonRepository>();// home/Add/
             
            services.Configure<SettingSite>(Configuration.GetSection(nameof(SettingSite)));
            services.AddScoped<Services>();//=>services.AddScoped<Services, Services>();  /home/GetService/

            services.AddTransient(typeof(IList<>), typeof(List<>));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseMiddleware<TransientTestMiddleware>();
            app.UseMiddleware<ScopeTestMiddleware>();
            app.UseMiddleware<SingletonTestMiddleware>();




            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
