using Borda.Service.DotnetCore.Contexts;
using Location.Service.Domain.LocationLevels;
using domain =Location.Service.Domain.Locations ;
using Microsoft.EntityFrameworkCore;
using Borda.Service.DotnetCore.Contexts.Extensions;
using Location.Service.Infrastructure.Processing.InternalCommands;

namespace Location.Service.Infrastructure.Database
{
    public class LocationContext : BaseContext
    {
        public LocationContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<InternalCommand> InternalCommands { get; set; }
        public DbSet<domain.Location> Locations { get; set; }
        public DbSet<LocationLevel> LocationLevels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurations
           // modelBuilder.ApplyConfiguration(new LocationConfiguration());
           // modelBuilder.ApplyConfiguration(new LocationLocationGroupConfiguration());
            //modelBuilder.ApplyConfiguration(new LocationGroupConfiguration());

            modelBuilder
                .SetDeleteBehaviorForForeignKeys(DeleteBehavior.Cascade)
                .UseIdentityAlwaysColumns(); // postgres identity column
        }
    }
}
