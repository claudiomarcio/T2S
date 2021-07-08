using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using T2S.Infra.Data;
using T2S.Infra.Data.UoW;
using System;
using System.IO;
using System.Reflection;
using T2S.Domain.ConteinerAggregate;
using T2S.Infra.Data.Conteiner;
using T2S.Domain.MovimentacaoAggregate;
using T2S.Infra.Data.Movimentacao;

namespace T2S.API
{
    public class Startup
    {
        public static string EmbeddedReportsPrefix = "AR14_AspNetCore.Reports";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var assembly = AppDomain.CurrentDomain.Load("T2S.Application");
            services.AddMediatR(assembly);
            services.AddAutoMapper(assembly);
            services.AddSignalR();

            services.AddScoped<IConteinerRepository, ConteinerRepository>();
            services.AddScoped<IMovimentacaoRepository, MovimentacaoRepository>();  
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<T2SContext>(options =>
                options.UseSqlite(
                    $@"Data Source={$@"{AppDomain.CurrentDomain.BaseDirectory}\t2s.db"}",
                    o => o.MigrationsAssembly("T2S.API"))
            );


            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

            services.AddMvc();
            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Prova T2S", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath);
            });
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
                           .AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader());

            app.UseAuthentication();
            app.UseDefaultFiles();
            app.UseStaticFiles();
           
            app.UseRouting(); 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Prova T2S V1");
            });
          
        }
    }
}
