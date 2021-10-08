using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StoreDomain.StoreContext.Handlers;
using StoreDomain.StoreContext.Repositories;
using StoreDomain.StoreContext.Services;
using StoreInfra.Services;
using StoreInfra.StoreContext.DataContexts;
using StoreInfra.StoreContext.Repositories;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using StoreShared;

namespace StoreApi
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

            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddResponseCompression();

            // No scoped, ele vai verificar se tem algum na memória e vai utilizar. Isso por transação.
            services.AddScoped<BaltaDataContext, BaltaDataContext>();
            // No transient sempre que for solicitado um repository será instanciado um novo.
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerHandler, CustomerHandler>();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Store", Version = "V1" });
            });

            Settings.ConnectionString = $"{Configuration["ConnectionString"][0]}";
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Store"));
            }

            app.UseRouting();

            app.UseMvc();
            app.UseResponseCompression();


            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapGet("/", async context =>
            //     {
            //         await context.Response.WriteAsync("Hello World from startup!");
            //     });
            // });
        }
    }
}
