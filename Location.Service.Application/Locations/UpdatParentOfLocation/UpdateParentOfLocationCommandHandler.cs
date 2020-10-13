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
using AutoMapper;

namespace Location.Service.Application.Locations.UpdatParentOfLocation
{
    public class UpdateParentOfLocationCommandHandler : ICommandHandler<UpdateParentOfLocationCommand, LocationDto>
    {
        private readonly ILocationRepository LocationRepository;
        private readonly ILocationUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;
       
        public UpdateParentOfLocationCommandHandler(
            ILocationUnitOfWork unitOfWork,
            IMapper mapper,
            ILocationRepository locationRepository)
        {
            this.LocationRepository = locationRepository;
            this.UnitOfWork = unitOfWork;
            this.Mapper = mapper;
           
        }
        public async Task<LocationDto> Handle(UpdateParentOfLocationCommand request, CancellationToken cancellationToken)
        {
            var location = await this.LocationRepository.GetByIdAsync(request.Id,false);
            location.UpdateParent(request.ParentId);
            return Mapper.Map<LocationDto>(location);
        }
    }
}
