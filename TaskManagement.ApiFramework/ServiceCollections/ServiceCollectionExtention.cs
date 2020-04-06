using System;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using TaskManagement.Data;
using TaskManagement.Data.Contracts;
using TaskManagement.Data.Contracts.BaseInfoInitialize;
using TaskManagement.Data.Contracts.EntityContract;
using TaskManagement.Services.ContractService;
using TaskManagement.Services.ContractService.BaseInfoInitializeService;
using TaskManagement.Services.ContractService.EntityContractService;
using TMS.Data.Services;

namespace TaskManagement.ApiFramework.ServiceCollections
{
    public static class ServiceCollectionExtention
    {
        public static void AddCustomContext(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<MyAppContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Con"));
            });
        }
        public static void AddDependency(this IServiceCollection services)
        {
            services.AddScoped<IJwtRpository, JwtService>();
            services.AddScoped<IUnitOfWork, MyUnitOfWork>();
            services.AddScoped<IUserRepository, UserService>();
            services.AddScoped<ITicketRepository, TicketService>();
            services.AddScoped<DataSeedingRepository, AccessDataSeedingService>();
        }
 
        public static void AddSwagger(this IServiceCollection service)
        {
            service.AddSwaggerGen(op =>
            {
                op.SwaggerDoc("v1", new OpenApiInfo() {Version = "v1", Title = "API V1"});
                op.OperationFilter<AddAuthorizationHeaderParameterOperationFilter>();
            });
        }
    }
}