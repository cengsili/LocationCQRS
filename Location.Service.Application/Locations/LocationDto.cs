using AutoMapper;


namespace Location.Service.Application.Locations.GetBranchLocations
{
    [AutoMap(typeof(Location.Service.Domain.Locations.Location), ReverseMap = true)]
    public class LocationDto
    {
        public string Name { get; set; }
        public string LocationCode { get; set; }
    }
}
