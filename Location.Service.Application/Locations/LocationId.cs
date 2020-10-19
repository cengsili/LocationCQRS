using Location.Service.Domain.SeedWork;
using System;

namespace Location.Service.Application.Locations
{

    public class LocationId : TypedIdValueBase
    {
        public LocationId(Guid value) : base(value)
        {
        }
    }
}
