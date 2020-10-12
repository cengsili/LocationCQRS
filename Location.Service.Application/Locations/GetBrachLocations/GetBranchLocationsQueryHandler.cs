using Location.Service.Application.Configuration.Queries;
using Location.Service.Domain.Locations;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Location.Service.Application.Locations.GetBranchLocations
{

    internal sealed class GetBranchLocationsQueryHandler : IQueryHandler<GetBranchLocationsQuery, List<LocationDto>>
    {
        private ILocationRepository locationRepository;
        
        public GetBranchLocationsQueryHandler(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }
        public async Task<List<LocationDto>> Handle(GetBranchLocationsQuery request, CancellationToken cancellationToken)
        {
            var locationlist = locationRepository.GetBranchLocations(request.BranchId);
            var locationDtoList = locationlist.Select(e =>new LocationDto(){
                                                            Name=e.Name,
                                                            LocationCode= e.ManualCode
                                                         }).ToList();
            return locationDtoList;
        }
    }
}
