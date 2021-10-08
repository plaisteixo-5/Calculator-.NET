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

namespace StoreApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);
            // No scoped, ele vai verificar se tem algum na memória e vai utilizar. Isso por transação.
            services.AddScoped<BaltaDataContext, BaltaDataContext>();
            // No transient sempre que for solicitado um repository será instanciado um novo.
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerHandler, CustomerHandler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseMvc();
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
