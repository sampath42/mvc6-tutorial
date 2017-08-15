using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace MVC6.Training
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private IFoo _foo;

        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next, IFoo foo)
        {
            _next = next;
            _foo = foo;
        }

        public Task Invoke(HttpContext httpContext)
        {
            return httpContext.Response.WriteAsync("In Middleware: " + _foo.GetFoo());
            //return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
