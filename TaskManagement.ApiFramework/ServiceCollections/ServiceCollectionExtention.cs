using System;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Data;
using TaskManagement.Data.Contracts;
using TaskManagement.Data.Contracts.EntityContract;
using TaskManagement.Services.ContractService;
using TaskManagement.Services.ContractService.EntityContractService;
using TMS.Data.Services;

namespace TaskManagement.ApiFramework.ServiceCollections
{
    public static class ServiceCollectionExtention
    {
        public static void AddCustomContext(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<MyAppContext>(options => { options.UseSqlServer(configuration.GetConnectionString("AppCon")); });
        }
        public static void AddDependency(this IServiceCollection services)
        {
            services.AddTransient<IJwtRpository, JwtService>();
            services.AddTransient<IUnitOfWork, MyUnitOfWork>();
            services.AddTransient<IUserRepository, UserService>();
        }
    }
}