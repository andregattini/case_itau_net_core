using CaseItau.API.DataContext;
using CaseItau.API.DataContext.Interface;
using CaseItau.API.Repository;
using CaseItau.API.Repository.Interface;
using CaseItau.API.Service;
using CaseItau.API.Service.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CaseItau.API
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

            services.AddScoped<IFundRepository, FundRepository>();
            services.AddScoped<IFundTypeRepository, FundTypeRepository>();
            services.AddScoped<IFundService, FundService>();
            services.AddScoped<IFundTypeService, FundTypeService>();
            services.AddScoped<string>(provider => Configuration.GetSection("ConnectionString").Value);
            services.AddScoped<ISqlConnection, SqlConnection>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
