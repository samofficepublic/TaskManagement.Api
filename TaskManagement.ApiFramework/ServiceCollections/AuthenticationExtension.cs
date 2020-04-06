using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using TaskManagement.ApiFramework.Api;
using TaskManagement.Common.Enums;
using TaskManagement.Common.Utils;
using TaskManagement.Data.Contracts.EntityContract;
using TaskManagement.Entity.DomainModels;


namespace TaskManagement.ApiFramework.ServiceCollections
{
    public static class AuthenticationExtension
    {
        public static IServiceCollection AddTokenAuthentication(this IServiceCollection services, IConfiguration config, SiteSettings siteSettings)
        {
            var key = Encoding.ASCII.GetBytes(siteSettings.jwtSettings.SecretKey);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = siteSettings.jwtSettings.Issuer,
                        ValidAudience = siteSettings.jwtSettings.Audience
                    };
                });

            return services;
        }


        public static void AddJwtAuthentication(this IServiceCollection services, JwtSettings jwtSettings )
        {
            services.AddAuthorization();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var secretkey = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);
                var encryptionkey = Encoding.UTF8.GetBytes(jwtSettings.Encryptkey);

                var validationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.Zero, // default: 5 min
                    RequireSignedTokens = true,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretkey),

                    RequireExpirationTime = true,
                    ValidateLifetime = true,

                    ValidateAudience = true, //default : false
                    ValidAudience = jwtSettings.Audience,

                    ValidateIssuer = true, //default : false
                    ValidIssuer = jwtSettings.Issuer,

                    TokenDecryptionKey = new SymmetricSecurityKey(encryptionkey)
                };

                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = validationParameters;
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        var logger = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(JwtBearerEvents));
                        //logger.LogError("Authentication failed.", context.Exception);
                        logger.LogError("Authentication Failed...",context.Exception);

                        if (context.Exception != null)
                            throw new ApiException(ApiResultStatusCode.UnAuthorized, "Authentication failed.", HttpStatusCode.Unauthorized, context.Exception, null);

                        return Task.CompletedTask;
                    }
                    //,

                    //OnChallenge = context =>
                    //{
                    //    //var logger = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(JwtBearerEvents));
                    //    //logger.LogError("OnChallenge error", context.Error, context.ErrorDescription);

                    //    if (context.AuthenticateFailure != null)
                    //        throw new ApiException(ApiResultStatusCode.UnAuthorized, "Authenticate failure.", HttpStatusCode.Unauthorized, context.AuthenticateFailure, null);
                    //    throw new ApiException(ApiResultStatusCode.UnAuthorized, "You are unauthorized to access this resource.", HttpStatusCode.Unauthorized);

                    //    //return Task.CompletedTask;
                    //}
                };
            });
        }
    }
}
