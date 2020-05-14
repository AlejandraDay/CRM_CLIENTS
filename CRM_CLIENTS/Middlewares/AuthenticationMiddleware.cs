using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using BusinessLogic.BusinessLogic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace CRM_CLIENTS.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthenticationMiddleware
    {

        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            LoginLogic loglogic = new LoginLogic();
            string var = httpContext.Request.Headers["authorization"].ToString();
            // var = "mateo.lopez<3:Pass123"
            Console.WriteLine("This is the Auth Middleware");
            Console.WriteLine("Connecting with FB API (oAuth)"); // SSO, oAuth2.0/3.0
            Console.WriteLine("waiting for FB credentials");
            Console.WriteLine("optional: store JWT token to our db (through businness logic)");
            Console.WriteLine("GRANTING ACCESS TO THE SYSMTEM");
            // Consult to busines logic
            // Consutl to DB if user exists or not (user/pass)
            // HTTP Header / Authorization: Basic base64(user:pass)
            // GRANT Acess

            if( loglogic.ValidateUser(var))
            {
                return _next(httpContext);
            }else
                {
                throw new AuthenticationException("Unauthorized Access, Username Or password Invalid");
                }


            
            //else 
            //  throw new unauthorized 
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthorizationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}
