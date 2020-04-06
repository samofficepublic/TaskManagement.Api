using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
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
using TaskManagement.Data.Contracts;
using TaskManagement.Data.Contracts.BaseInfoInitialize;
using TaskManagement.Services.ContractService;
using TaskManagement.Services.ContractService.BaseInfoInitializeService;

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

     public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<SiteSettings>(Configuration.GetSection(nameof(SiteSettings)));

            services.AddControllers();

            services.AddSwagger();

            services.AddDependency();

            services.AddCustomContext(Configuration);

            services.AddApiVersioning();

            services.AddJwtAuthentication(_siteSetting.jwtSettings);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerExtention();

            loggerFactory.AddNLog();

            app.UseCustomException();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors(c =>
            {
                c.AllowAnyOrigin();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
