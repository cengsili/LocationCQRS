using Location.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Location.Service.Domain.LocationLevels
{
    [Table("LocationLevel")]
    public class LocationLevel : BaseEntity
    {
        public string Name { get; set; }

        public int? ParentLocationLevelId { get; set; }

        public LocationLevel ParentLocationLevel { get; set; }

        public int BranchId { get; set; }

        public int? SystemId { get; set; }

        public int Level { get; set; }
    }
}
