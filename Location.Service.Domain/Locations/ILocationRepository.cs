using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Location.Service.Domain.Locations
{
    public interface ILocationRepository
    {
        Task<List<Location>> GetBranchLocations(int branchid);
        Task<Location> GetByIdAsync(int id, bool asNoTracking = false);
    }
}
