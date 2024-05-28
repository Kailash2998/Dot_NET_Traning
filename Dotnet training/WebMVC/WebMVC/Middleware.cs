using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebMVC
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }
        /// <summary>
        /// Custom middleware
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public Task Invoke(HttpContext httpContext)
        {
            /* httpContext.Response.WriteAsync("Hello from custom middle ware\n");*/
            Console.WriteLine("Hello from the middleware");
            return _next(httpContext);
        }
    }

    /// <summary>
    /// Extension method used to add the middleware to the HTTP request pipeline.
    /// </summary>
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
