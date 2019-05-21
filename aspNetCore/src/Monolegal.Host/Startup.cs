using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Monolegal.AplicacionCore.Interfaces.IRepositorios;
using Monolegal.AplicacionCore.Interfaces.IServicios;
using Monolegal.AplicacionCore.Servicios;
using Monolegal.AplicacionCore.Utilidades.Configuraciones;
using Monolegal.Host.Auxiliares;
using Monolegal.Infraestructura.Repositorios;
using Swashbuckle.AspNetCore.Swagger;

namespace Monolegal.Host
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.Configure<Mongo>(Configuration.GetSection("Mongo"));
            services.AddScoped(typeof(IRepositorioBaseAsync), typeof(RepositorioBaseAsync));
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IClienteServicio, ClienteServicio>();
            services.AddScoped<IFacturaRepositorio, FacturaRepositorio>();
            services.AddScoped<IFacturaServicio, FacturaServicio>();
            services.AddSingleton(new MapperConfiguration(a => a.AddProfile(new MapeoProfile())).CreateMapper());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "API Monolegal",
                    Description = "Gestion de Facturas para Clientes"
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Monolegal");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
