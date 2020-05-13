using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using BusinessLogic.Exceptions;
using CDM_CLIENTS.Database.Exceptions;
using Newtonsoft.Json;

namespace CRM_CLIENTS.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await ProcessError(httpContext, ex);
                
            }
        }
        private static int getCode(Exception ex)
        {
            int code = 500;
            if (ex.GetType() == typeof(CodeDoesNotExistException))
                code = ((CodeDoesNotExistException)ex).Code;
            if (ex.GetType() == typeof(CodeAlreadyExistsException))
                code = ((CodeAlreadyExistsException)ex).Code;
            if (ex.GetType() == typeof(DatabaseException))
                code = ((DatabaseException)ex).Code;
            if (ex.GetType() == typeof(EmptyNameException))
                code = ((EmptyNameException)ex).Code;
            if (ex.GetType() == typeof(EmptyCiException))
                code = ((EmptyCiException)ex).Code;
            if (ex.GetType() == typeof(RankingOutOfBoundException))
                code = ((RankingOutOfBoundException)ex).Code;
            return code;
        }

        private static Task ProcessError(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            var errorObj = new
            {
                code = getCode(ex),
                message = ex.Message
            };

            string jsonObj = JsonConvert.SerializeObject(errorObj);
            context.Response.StatusCode = getCode(ex);
            return context.Response.WriteAsync(jsonObj);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
