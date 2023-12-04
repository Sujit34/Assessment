using Assignment.Api.Extensions;
using Assignment.Business;
using Assignment.Contract.Utility;
using Assignment.Data;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Assignment.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Common.CountryCodeLength = configuration.GetValue<int>("CountryCodeLength");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerDocumentation();
            services.AddCors();           
            ConfigureControllerWithFluentValidation(services);
            services.AddRepositoryDependency();
            services.AddBusinessDependency();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder =>
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerDocumentation();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void ConfigureControllerWithFluentValidation(IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(fvc =>
                {                    
                    fvc.ImplicitlyValidateRootCollectionElements = true;
                });
        }
    }
}
