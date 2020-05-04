using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Itau.Case.ClubesFutebol.Core.Contracts;
using Itau.Case.ClubesFutebol.Core.Dtos;
using Itau.Case.ClubesFutebol.Core.Services;
using Itau.Case.ClubesFutebol.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using AutoMapper;

namespace Itau.Case.ClubesFutebol.Application
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
            //services
            services.AddScoped<ICampeonatoService, CampeonatoService>();
            services.AddScoped<IClubeService, ClubeService>();
            //repository
            services.AddScoped<ICampeonatoRepository, CampeonatoRepository>();
            services.AddScoped<IClubeRepository, ClubeRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
            //mongo connection
            services.Configure<DBClubeSettings>(
                 Configuration.GetSection(nameof(DBClubeSettings)));

            services.AddSingleton<IDBClubeSettings>(sp =>
                sp.GetRequiredService<IOptions<DBClubeSettings>>().Value);
            //mapper
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Clubes de Futebol API",
                    Description = "API do serviço Clubes de Futebol.\n\nVersão v1" + ". <style>.models {display: none !important}</style>",
                    Contact = new OpenApiContact() { Name = "Monike Stephany", Email = "monikestephany@gmail.com", Url = new Uri("https://www.linkedin.com/monike-stephany-developer/") }
                });

            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clubes de Futebol API");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
