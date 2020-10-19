using Borda.Service.DotnetCore.Repositories;
using Location.Service.Domain.Locations;
using Location.Service.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain = Location.Service.Domain.Locations;

namespace Location.Service.Infrastructure.Repositories
{
    public class LocationRepository : CrudRepository<LocationContext, domain.Location, int>, ILocationRepository
    {
        private readonly LocationContext context;
        public LocationRepository(IEFOperations<LocationContext> efOperations) : base(efOperations)
        {
            this.context = context;
        }

        public async Task<List<domain.Location>> GetBranchLocations(int branchid)
        {
            return await EFOperations.GetQueryable<domain.Location>(true)
                .Where(e => e.BranchId == branchid).ToListAsync();               
        }

        public async Task<domain.Location> GetByIdAsync(int id,bool asNoTracking =false)
        {
            return await EFOperations.GetQueryable<domain.Location>(asNoTracking)
                .FirstOrDefaultAsync(predicate => predicate.Id == id);
        }
    }
}
