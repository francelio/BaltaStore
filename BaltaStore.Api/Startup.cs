using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.Services;
using BaltaStore.Infra.DataContexts;
using BaltaStore.Infra.StoreContext.Repositories;
using BaltaStore.Infra.StoreContext.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.Configuration;
using System.IO;
using BaltaStore.Shared;

namespace BaltaStore.Api
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            services.AddMvc();
            
            // services.AddResponseCompression(); //adicionando a compressão de dados
            services.AddScoped<BaltaDataContext,BaltaDataContext>();//Version se tem um na memoria e usa
            services.AddTransient<ICustomerRepository,CustomerRepository>();//instância um novo
            services.AddTransient<IEmailService,EmailService>();
            services.AddTransient<CustomerHandler,CustomerHandler>();
            
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "Balta Store", Version = "v1" });
            });

             Settings.ConnectionString = $"{Configuration["connectionString"]}";
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
            // usando compressão
            // app.UseResponseCompression();

           // Ativando middlewares para uso do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "BaltaStoreV1");
            });            
        // }
        }
    }
}
