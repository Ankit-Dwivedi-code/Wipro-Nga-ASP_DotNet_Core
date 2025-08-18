using Day26_aggignment1.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Day26_aggignment1
{
    public class Strartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages(); // If needed later
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Custom error page for unhandled exceptions
                app.UseExceptionHandler("/error.html");
                app.UseHsts();
            }

            // Force HTTPS
            app.UseHttpsRedirection();

            // Logging middleware
            app.UseRequestResponseLogging();

            // Serve static files from wwwroot
            app.UseStaticFiles();

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from MiddlewareApp!");
            });
        }
    }
}
