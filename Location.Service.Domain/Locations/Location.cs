using Location.Domain;
using Location.Service.Domain.LocationLevels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Location.Service.Domain.Locations
{
    [Table("Location")]
    public class Location : BaseEntity
    {
        public string Name { get; set; }

        public string AutoCodeParent { get; set; }

        public int AutoCodeOwn { get; set; }

        public string ManualCode { get; set; }

        public int? ParentLocationId { get; set; }

       // public Location ParentLocation { get; set; }

        public int? LocationTagId { get; set; }

      

        public int LocationLevelId { get; set; }

     ///   public LocationLevel LocationLevel { get; set; }

        public int Index { get; set; }

        public double Area { get; set; }

        public string Description { get; set; }

        public int BranchId { get; set; }

       
       // public List<Location> ChildLocations { get; set; }
       public Location UpdateParentOfLocation(int parentId, int id)
       {
            return new Location();
       }
    }
}
