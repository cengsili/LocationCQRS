using Location.Service.Application.Configuration.Commands;
using Location.Service.Application.Locations.GetBranchLocations;
using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace Location.Service.Application.Locations.UpdatParentOfLocation
{
    public class UpdateParentOfLocationCommand:CommandBase<LocationDto>
    {
        public int Id { get; }
        public int ParentId { get;  }
      
        public UpdateParentOfLocationCommand(int id ,int parentId)
        {
            this.Id = id;
            this.ParentId = parentId;
        }
    }
}
