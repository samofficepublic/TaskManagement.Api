using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TaskManagement.Common.Enums;
using TaskManagement.Common.Extentions;

namespace TaskManagement.ApiFramework.Api
{
    public class ApiResult
    {
        public ApiResultStatusCode ApiResultStatusCode { get; set; }
       
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        public ApiResult(ApiResultStatusCode apiResultStatusCode, string message = null)
        {
            ApiResultStatusCode = apiResultStatusCode;

            Message = message ?? apiResultStatusCode.ToDisplay();
        }

        public static implicit operator ApiResult(OkResult result)
        {
            return new ApiResult(ApiResultStatusCode.Success);
        }

        public static implicit operator ApiResult(BadRequestResult result)
        {
            return new ApiResult(ApiResultStatusCode.BadRequest);
        }

        public static implicit operator ApiResult(BadRequestObjectResult result)
        {
            var message = result.Value.ToString();
            if (result.Value is SerializableError error)
            {
                var errorMessages = error.SelectMany(p => (string[])p.Value).Distinct();
                message = string.Join("|", errorMessages);
            }
            return new ApiResult(ApiResultStatusCode.BadRequest, message);
        }

        public static implicit operator ApiResult(ContentResult result)
        {
            return new ApiResult(ApiResultStatusCode.Success, result.Content);
        }

        public static implicit operator ApiResult(NotFoundResult result)
        {
            return new ApiResult(ApiResultStatusCode.NotFound);
        }
    }
    public class ApiResult<TData> : ApiResult where TData : class
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public TData Data { get; set; }
        public ApiResult(ApiResultStatusCode apiResultStatusCode,TData data, string message = null ) : base(apiResultStatusCode, message)
        {
            Data = data;
        }

        public static implicit operator ApiResult<TData>(TData data)
        {
            return  new ApiResult<TData>(ApiResultStatusCode.Success,data);
        }

        public static implicit operator ApiResult<TData>(OkResult result)
        {
            return  new ApiResult<TData>(ApiResultStatusCode.Success,null);
        }

        public static implicit operator ApiResult<TData>(OkObjectResult result)
        {
            return  new ApiResult<TData>(ApiResultStatusCode.Success,(TData)result.Value);
        }

        public static implicit operator ApiResult<TData>(BadRequestResult result)
        {
            return  new ApiResult<TData>(ApiResultStatusCode.BadRequest,null);
        }

        public static implicit operator ApiResult<TData>(BadRequestObjectResult result)
        {
            var message = result.Value.ToString();
            if (result.Value is SerializableError error)
            {
                var errorMessages = error.SelectMany(p => (string[]) p.Value).Distinct();
                message = string.Join("|", errorMessages);
            }
            return  new ApiResult<TData>(ApiResultStatusCode.BadRequest,null,message);
        }

        public static implicit operator ApiResult<TData>(ContentResult result)
        {
            return  new ApiResult<TData>(ApiResultStatusCode.Success,null,result.Content);
        }

        public static implicit operator ApiResult<TData>(NotFoundResult result)
        {
            return  new ApiResult<TData>(ApiResultStatusCode.NotFound,null);
        }

        public static implicit operator ApiResult<TData>(NotFoundObjectResult result)
        {
            return  new ApiResult<TData>(ApiResultStatusCode.NotFound,(TData)result.Value);
        }
    }
}
