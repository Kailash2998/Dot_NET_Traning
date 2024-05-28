namespace AssignmentNo2.NetCore
{
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
            httpContext.Response.WriteAsync("Hello from custom middle ware\n");
            return _next(httpContext);
        }
    }

    #region GET
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
    #endregion
}

