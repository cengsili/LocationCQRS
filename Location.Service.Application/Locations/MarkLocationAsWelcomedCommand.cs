using Location.Service.Application.Configuration.Commands;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Location.Service.Application.Locations
{
    public class MarkLocationAsWelcomedCommand : InternalCommandBase<Unit>
    {
        [JsonConstructor]
        public MarkLocationAsWelcomedCommand(Guid id, LocationId locationId) : base(id)
        {
            LocationId = locationId;
        }

        public LocationId LocationId { get; }
    }
}
