using Borda.Service.DotnetCore.Repositories;
using Location.Service.Domain.Locations;
using Location.Servise.Insfrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain = Location.Service.Domain.Locations;

namespace Location.Service.Insfrastructure.Repositories
{
    public class LocationRepository : CrudRepository<LocationContext, domain.Location, int>, ILocationRepository
    {
        private readonly LocationContext context;

        public LocationRepository(IEFOperations<LocationContext> efOperations, LocationContext context) : base(efOperations)
        {
            this.context = context;
        }

        public List<domain.Location> GetBranchLocations(int branchid)
        {
            try
            {
                return EFOperations.GetQueryable<domain.Location>(true)
               .Where(e => e.BranchId == branchid)
               .ToList();
            }
            catch (Exception e)
            {

                return new List<domain.Location>();
            }
           
        }


    }
}
