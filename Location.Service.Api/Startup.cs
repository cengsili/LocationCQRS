using Borda.Service.DotnetCore.Repositories;
using Location.Service.Application.Locations.GetBranchLocations;
using Location.Service.Application.Locations.UpdatParentOfLocation;
using Location.Service.Domain;
using Location.Service.Domain.Locations;
using Location.Service.Infrastructure.Database;
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
using Location.Service.Api.Configuration;
using Location.Service.Application;
using Microsoft.AspNetCore.Http;
using Location.Service.Infrastructure;
using Location.Service.Application.Configuration;
using Hellang.Middleware.ProblemDetails;
using Location.Service.Domain.SeedWork;
using Location.Service.Api.SeedWork;

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
        public IServiceProvider ConfigureServices(IServiceCollection services)
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
            services.AddSwaggerDocumentation();
            services.AddProblemDetails(x =>
            {
               // x.Map<InvalidCommandException>(ex => new InvalidCommandProblemDetails(ex));
                x.Map<BusinessRuleValidationException>(ex => new BusinessRuleValidationExceptionProblemDetails(ex));
            });

            services.AddHttpContextAccessor();
            var serviceProvider = services.BuildServiceProvider();

            IExecutionContextAccessor executionContextAccessor = new ExecutionContextAccessor(serviceProvider.GetService<IHttpContextAccessor>());
            services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
            }, AppDomain.CurrentDomain.GetAssemblies());

            return ApplicationStartup.Initialize(services, executionContextAccessor) ;


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<CorrelationMiddleware>();
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
            app.UseSwaggerDocumentation();

        }
        private void AutoMigrate(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<LocationContext>();
            context.Database.Migrate();
        }
    }
}
