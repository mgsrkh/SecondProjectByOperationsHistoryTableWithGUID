using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SecondProjectByOperationsHistoryTableWithGUID.ApplicationServices.IServices;
using SecondProjectByOperationsHistoryTableWithGUID.ApplicationServices.Services;
using SecondProjectByOperationsHistoryTableWithGUID.Contexts;
using SecondProjectByOperationsHistoryTableWithGUID.InferaStructure.IRepositories;
using SecondProjectByOperationsHistoryTableWithGUID.InferaStructure.Repositories;

namespace SecondProjectByOperationsHistoryTableWithGUID
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();

            services.AddDbContext<ProjectContext>(option => option
            .UseSqlServer(_configuration["ConnectionString"]));


            services.AddScoped<IVendorRepository, VendorRepository>();
            services.AddScoped<IHistoryRepository, HistoryRepository>();
            services.AddScoped<IVendorService, VendorService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Test1 Api v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
