using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EnviromentPro
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public sitesetting1 Sitesetting { get; set; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            var OS = _configuration["OS"];                 //system enviroment variabels

            var firstname = _configuration["firstname"];  //setting  
            var firstname1 = _configuration.GetSection("firstname").Value;  //setting  

            var lastname = _configuration["lastname"];   //setting  

            var lastname1 = _configuration["PersonalData:LastName"];   //setting  
            var lastname12 = _configuration.GetSection("PersonalData").GetSection("LastName").Value;   //setting  

            var secretkey = _configuration["pass"]; //right on project/manage user secret




            //--------------------------------------روش اول----------------------------------------------
            // دریافت اطلاعات از طریق 
            //1-IOptions<sitesetting1>
            //2-IOptionsSnapshot<sitesetting1>

            services.Configure<sitesetting1>(_configuration.GetSection(nameof(sitesetting1)));
            services.AddScoped<TestService>();
            //public TestService(IOptions<sitesetting1> options, IOptionsSnapshot<sitesetting1> optionsSnapshot)
            //{
            //    var sitename = options.Value.sitename;
            //    var sitename1 = optionsSnapshot.Value.sitename;
            //}





            //-------------------------روش دوم قسمت 1-------------------------------------
            //در این روش نیاز به نیو کردن کلاس ندارد خودش به صورت اتومات ایجاد می کند
            // Sitesetting = _configuration.GetSection(nameof(sitesetting1)).Get<sitesetting1>();
            // services.AddSingleton(Sitesetting);

            //-------------------------روش دوم قسمت 2-------------------------------------
            Sitesetting = new sitesetting1();
            _configuration.GetSection(nameof(sitesetting1)).Bind(Sitesetting);
            services.AddSingleton(Sitesetting);
            
            //public testController(sitesetting1 sitesetting)
            //{
            //    this.sitesetting = sitesetting;
            //}
            //------------------------------------------------------------------------------


            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
