using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TaskManagement.ApiFramework.ServiceCollections
{
    public class AddAuthorizationHeaderParameterOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
             
            var authAttributes = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .OfType<AuthorizeAttribute>();

            var allowAnonymouseAttributes = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .OfType<IAllowAnonymous>();

            if (authAttributes.Any() && !allowAnonymouseAttributes.Any())
            {
                operation.Parameters.Add(new OpenApiParameter()
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Description = "Access Token",
                    Required = true,
                    Schema = new OpenApiSchema()
                    {
                        Type = "string",
                        Default = new OpenApiString("Bearer ")
                    }
                });
            }
        }
    }
}
