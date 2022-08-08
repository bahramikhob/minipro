using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistributedCachePro
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {



            //=========================setting session Destribute=====================
            //1-install package=> Microsoft.Extensions.Caching.SqlServer

            //2-Create Table Cache:open cmd run command:
                       //dotnet tool install--global dotnet-sql - cache در صورتی که دات نت اسکیول نصب نباشد
                       //dotnet sql-cache create "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=logger;Data Source=." dbo mytablecache

            //3- Replace  services.AddDistributedMemoryCache(); with :
            services.AddDistributedSqlServerCache(s =>
            {
                s.ConnectionString = "Integrated Security = SSPI; Persist Security Info = False; Initial Catalog = logger; Data Source =.";
                s.SchemaName = "dbo";
                s.TableName = "mytablecache";
            });

            services.AddSession(c =>
            {
                c.Cookie.IsEssential = true;
                //c.Cookie.Expiration = TimeSpan.FromMinutes(30);
                c.IdleTimeout = TimeSpan.FromMinutes(30);//مدت زمانی که هیچ درخواستی ارسال نشود منقضی گردد
                c.Cookie.Name = "sessionid";//نام کوکی که سشن ایدی دران ذخیره میشود
            });

            //4-add app.UseSession(); in Method Configure
            //===================================================================


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DistributedCachePro", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DistributedCachePro v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
