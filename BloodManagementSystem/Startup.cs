using BloodManagementSystem.Core.Interface;
using BloodManagementSystem.Core.Repository;
using BloodManagementSystem.DataAccess;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodManagementSystem
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
            services.AddControllers();
            services.AddDbContext<BloodDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("Connection")));
            services.AddScoped<IBlood, Blood>();
            services.AddSwaggerGen(gen =>
            {
                gen.SwaggerDoc("v1.0", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Employee Api",
                    Version = "v1.0"
                });
            });
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
            app.UseSwagger();
            app.UseSwaggerUI(i =>
            {
                i.SwaggerEndpoint("/Swagger/v1.0/swagger.json", "Employee API Endpoint");
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
