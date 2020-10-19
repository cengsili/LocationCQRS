using Autofac;
using Borda.Service.DotnetCore.Repositories;
using Location.Service.Domain;
using Location.Service.Domain.Locations;
using Location.Service.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Location.Service.Infrastructure.Database
{
    public class DataAccessModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(EFOperations<>))
             .As(typeof(IEFOperations<>));
            builder.RegisterType<LocationUnitOfWork>()
                .As<ILocationUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<LocationRepository>()
                .As<ILocationRepository>()
                .InstancePerLifetimeScope();

          
            
        }
    }
}
