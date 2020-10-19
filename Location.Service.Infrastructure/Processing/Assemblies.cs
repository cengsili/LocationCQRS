using Location.Service.Application.Locations.UpdatParentOfLocation;
using System.Reflection;

namespace Location.Service.Infrastructure.Processing
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(UpdateParentOfLocationCommand).Assembly;
    }
}
