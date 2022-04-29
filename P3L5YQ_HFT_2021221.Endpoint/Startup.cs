using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using P3L5YQ_HFT_2021221.Data;
using P3L5YQ_HFT_2021221.Logic;
using P3L5YQ_HFT_2021221.Repository;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using P3L5YQ_HFT_2021221.Endpoint.Services;

namespace P3L5YQ_HFT_2021221.Endpoint
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //DbContext
            services.AddScoped<DealershipDbContext, DealershipDbContext>();
            //repo
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<IEngineRepository, EngineRepository>();
            services.AddTransient<ITrimLevelRepository, TrimLevelRepository>();
            //logic
            services.AddTransient<ICarLogic, CarLogic>();
            services.AddTransient<IEngineLogic, EngineLogic>();
            services.AddTransient<ITrimLevelLogic, TrimLevelLogic>();
            //swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MovieDbApp.Endpoint", Version = "v1" });
            });
            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/ swagger / v1 / swagger.json", "MovieDbApp.Endpoint v1"));
            }
            app.UseCors(x => x
            .AllowCredentials()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:53339"));
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
            
        }
    }
}
