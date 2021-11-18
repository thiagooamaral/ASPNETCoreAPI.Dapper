using System;
using System.IO;
using Elmah.Io.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.Configuration;
using BaltaStore.Infra.StoreContext.Services;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Domain.StoreContext.Services;
using Microsoft.Extensions.DependencyInjection;
using BaltaStore.Infra.StoreContext.Repositories;
using BaltaStore.Infra.StoreContext.DataContexts;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Shared;

namespace BaltaStore.Api
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc();

            services.AddResponseCompression();

            services.AddScoped<BaltaDataContext, BaltaDataContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerHandler, CustomerHandler>();

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
            app.UseResponseCompression();

            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Balta Store - v1");
            });

            // Alterar pelas informações do Elmah
            app.UseElmahIo("923f4c946cc1435cb0ec665d6e7370b7", new Guid("e42a9995-df89-4d91-a625-ecc57d124004"));
        }
    }
}
