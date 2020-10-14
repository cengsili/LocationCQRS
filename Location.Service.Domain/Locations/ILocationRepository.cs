using Borda.Service.DotnetCore.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Location.Service.Domain.Locations
{
    public interface ILocationRepository : ICrudRepository<Location, int>
    {
        Task<List<Location>> GetBranchLocations(int branchid);
        Task<Location> GetByIdAsync(int id, bool asNoTracking = false);
    }
}
