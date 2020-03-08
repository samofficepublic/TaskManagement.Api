using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TaskManagement.Common.Enums;

namespace TaskManagement.ApiFramework.Api
{
    public class ApiException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public ApiResultStatusCode ApiStatusCode { get; set; }
        public object AdditionalData { get; set; }

        public ApiException()
            : this(ApiResultStatusCode.ServerError)
        {
        }

        public ApiException(ApiResultStatusCode statusCode)
            : this(statusCode, null)
        {
        }

        public ApiException(string message)
            : this(ApiResultStatusCode.ServerError, message)
        {
        }

        public ApiException(ApiResultStatusCode statusCode, string message)
            : this(statusCode, message, HttpStatusCode.InternalServerError)
        {
        }

        public ApiException(string message, object additionalData)
            : this(ApiResultStatusCode.ServerError, message, additionalData)
        {
        }

        public ApiException(ApiResultStatusCode statusCode, object additionalData)
            : this(statusCode, null, additionalData)
        {
        }

        public ApiException(ApiResultStatusCode statusCode, string message, object additionalData)
            : this(statusCode, message, HttpStatusCode.InternalServerError, additionalData)
        {
        }

        public ApiException(ApiResultStatusCode statusCode, string message, HttpStatusCode httpStatusCode)
            : this(statusCode, message, httpStatusCode, null)
        {
        }

        public ApiException(ApiResultStatusCode statusCode, string message, HttpStatusCode httpStatusCode, object additionalData)
            : this(statusCode, message, httpStatusCode, null, additionalData)
        {
        }

        public ApiException(string message, Exception exception)
            : this(ApiResultStatusCode.ServerError, message, exception)
        {
        }

        public ApiException(string message, Exception exception, object additionalData)
            : this(ApiResultStatusCode.ServerError, message, exception, additionalData)
        {
        }

        public ApiException(ApiResultStatusCode statusCode, string message, Exception exception)
            : this(statusCode, message, HttpStatusCode.InternalServerError, exception)
        {
        }

        public ApiException(ApiResultStatusCode statusCode, string message, Exception exception, object additionalData)
            : this(statusCode, message, HttpStatusCode.InternalServerError, exception, additionalData)
        {
        }

        public ApiException(ApiResultStatusCode statusCode, string message, HttpStatusCode httpStatusCode, Exception exception)
            : this(statusCode, message, httpStatusCode, exception, null)
        {
        }

        public ApiException(ApiResultStatusCode statusCode, string message, HttpStatusCode httpStatusCode, Exception exception, object additionalData)
            : base(message, exception)
        {
            ApiStatusCode = statusCode;
            HttpStatusCode = httpStatusCode;
            AdditionalData = additionalData;
        }
    }
}
