namespace AssignmentNo2.NetCore
{
    public class Startup
    {
        /// <summary>
        /// Congiguring services
        /// </summary>
        /// <param name="services"></param>
        public void HelloServices(IServiceCollection services)
        {
            services.AddRazorPages();
        }
        /// <summary>
        /// Congigure
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.Use(async (context, next) =>
            {
                Console.WriteLine("Hello from Console\n");
                await next();
            });
            MiddleWareMap(app);
            MiddleWareUse(app);
            app.UseMiddleware();
            MiddleWareRun(app);
            app.Run();
        }

       

        /// <summary>
        /// Optimizing use 
        /// </summary>
        /// <param name="app"></param>
        private static void MiddleWareUse(WebApplication app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello \n");
                await next();
            });
        }
        /// <summary>
        /// optimizing map
        /// </summary>
        /// <param name="app"></param>
        private static void MiddleWareMap(WebApplication app)
        {
            app.Map("/test", variableDelegate =>
            {
                variableDelegate.Use(async (context, next) =>
                {
                    await context.Response.WriteAsync("this is test route\n");
                    await next();
                });
            });
        }

        /// <summary>
        /// optimizing Run
        /// </summary>
        /// <param name="app"></param>
        private static void MiddleWareRun(WebApplication app)
        {

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello this is using the run method midleware \n");

            });
        }
    }
}
