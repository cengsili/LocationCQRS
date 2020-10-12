using Location.Service.Application.Configuration.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Location.Service.Application.Locations.GetBranchLocations
{
   
    public class GetBranchLocationsQuery : IQuery<List<LocationDto>>
    { 
        public int BranchId {get;}
        public GetBranchLocationsQuery(int branchId)
        {
            this.BranchId = branchId;
        }
    }
}
