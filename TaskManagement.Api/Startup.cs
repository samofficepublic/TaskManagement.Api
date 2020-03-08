using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NLog.Extensions.Logging;
using TaskManagement.ApiFramework.ServiceCollections;
using TaskManagement.ApiFramework.ConfigMiddleware;
using TaskManagement.Common.Utils;

namespace TaskManagement.Api
{
    public class Startup
    {
        private readonly SiteSettings _siteSetting;
         
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _siteSetting = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
             
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<SiteSettings>(Configuration.GetSection(nameof(SiteSettings)));

            services.AddControllers();

            services.AddDependency();

            services.AddCustomContext(Configuration);

            services.AddApiVersioning();

            //services.AddTokenAuthentication(Configuration,_siteSetting);

            services.AddJwtAuthentication(_siteSetting.jwtSettings);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddNLog();

            app.UseCustomException();

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors(c => c.AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
