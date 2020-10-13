using Borda.Service.DotnetCore.Repositories;
using Location.Service.Application.Configuration.Commands;
using Location.Service.Application.Locations.GetBranchLocations;
using Location.Service.Domain.Locations;
using Location.Service.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Location.Service.Application.Locations.UpdatParentOfLocation
{
    public class UpdateParentOfLocationCommandHandler : ICommandHandler<UpdateParentOfLocationCommand, LocationDto>
    {
        private readonly ILocationRepository LocationRepository;
        private readonly ILocationUnitOfWork UnitOfWork;
       
        public UpdateParentOfLocationCommandHandler(ILocationUnitOfWork unitOfWork,ILocationRepository locationRepository)
        {
            this.LocationRepository = locationRepository;
            this.UnitOfWork = unitOfWork;
           
        }
        public async Task<LocationDto> Handle(UpdateParentOfLocationCommand request, CancellationToken cancellationToken)
        {
            var location = await this.LocationRepository.GetByIdAsync(request.Id,false);
            throw new NotImplementedException();
        }
    }
}
