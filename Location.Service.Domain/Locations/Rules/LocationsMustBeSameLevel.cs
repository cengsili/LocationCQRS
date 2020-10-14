using Location.Service.Domain.SeedWork;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Location.Service.Domain.Locations.Rules
{
    public class LocationsMustBeSameLevel : IBusinessRule
    {
        private readonly Location SourceLocation;
        private readonly Location TargetLocation;
       
        public LocationsMustBeSameLevel( Location sourceLocation,Location targetLocation)
        {
            this.SourceLocation = sourceLocation;
            this.TargetLocation = targetLocation;
        }
        public string Message => "Locations should be at same level";

        public bool IsBroken()
        {
            return this.SourceLocation.LocationLevelId != this.TargetLocation.LocationLevelId;
        }
    }
}
