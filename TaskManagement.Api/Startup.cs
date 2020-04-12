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
using TaskManagement.Data.Contracts.EntityContract;
using TaskManagement.Services.ContractService;
using TaskManagement.Services.ContractService.BaseInfoInitializeService;
using TaskManagement.Services.ContractService.EntityContractService;
using TMS.Data.Services;
using ServiceProvider = Microsoft.Extensions.DependencyInjection.ServiceProvider;

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
        public ILifetimeScope AutofacContainer { get; private set; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<SiteSettings>(Configuration.GetSection(nameof(SiteSettings)));

            services.AddControllers();

            services.AddSwagger();

            services.AddCustomContext(Configuration);

            services.AddApiVersioning();

            services.AddJwtAuthentication(_siteSetting.jwtSettings);
            //services.SeedData();
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.AddAutofacDependency();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.SeedData();

            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();

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
