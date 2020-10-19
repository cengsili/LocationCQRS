using Borda.Service.DotnetCore.Repositories;
using Location.Service.Domain;
using Location.Service.Infrastructure.Database;

using System;
using System.Collections.Generic;
using System.Text;

namespace Location.Service.Infrastructure.Repositories
{
    public class LocationUnitOfWork: UnitOfWork, ILocationUnitOfWork
    {
        public LocationUnitOfWork(LocationContext context) : base(context)
        {

        }
    }
}
