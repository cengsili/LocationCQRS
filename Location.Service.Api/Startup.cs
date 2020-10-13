using Borda.Service.DotnetCore.Repositories;
using Location.Service.Application.Locations.GetBranchLocations;
using Location.Service.Application.Locations.UpdatParentOfLocation;
using Location.Service.Domain;
using Location.Service.Domain.Locations;
using Location.Service.Infrastructure.Contexts;
using Location.Service.Infrastructure.Repositories;
using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Location.Api
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
            services.AddHttpContextAccessor();
            services.AddDbContext<LocationContext>(options =>
            {
                var conn = Configuration.GetConnectionString("DefaultConnection");
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"),
                    npSqlOptions =>
                    {
                        npSqlOptions.CommandTimeout(3300);
                    });
            });
          
            services.AddScoped<ILocationUnitOfWork, LocationUnitOfWork>();
            services.AddScoped(typeof(IEFOperations<>), typeof(EFOperations<>));            
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddMediatR(typeof(GetBranchLocationsQuery).Assembly);
            services.AddMediatR(typeof(UpdateParentOfLocationCommand).Assembly);

            services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
            }, AppDomain.CurrentDomain.GetAssemblies());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            AutoMigrate(app);

        }
        private void AutoMigrate(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<LocationContext>();
            context.Database.Migrate();
        }
    }
}
