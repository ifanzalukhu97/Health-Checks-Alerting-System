using System;
using health_checks_and_alerting.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace health_checks_and_alerting
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            SetDatabaseContext(services);

            ConfigureHealthChecks(services);
            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.MapHealthChecks("/health-check");
                
                endpoints.MapHealthChecks("/health-check/db", new HealthCheckOptions
                {
                    Predicate = check => check.Tags.Contains("db")
                });
                
                endpoints.MapControllers();
            });
        }

        protected virtual void SetDatabaseContext(IServiceCollection services)
        {
            services
                .AddEntityFrameworkSqlServer()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        }

        private void ConfigureHealthChecks(IServiceCollection service)
        {
            service
                .AddHealthChecks()
                .AddSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    tags: new[] { "db", "sql-server" },
                    timeout: TimeSpan.FromSeconds(5));
        }
    }
}