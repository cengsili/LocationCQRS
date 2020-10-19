using Location.Service.Application.Locations;
using Location.Service.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Location.Service.Infrastructure.Processing
{
    public class CommandsDispatcher : ICommandsDispatcher
    {
        private readonly IMediator _mediator;
        private readonly LocationContext _LocationContext;

        public CommandsDispatcher(
            IMediator mediator,
            LocationContext LocationContext)
        {
            this._mediator = mediator;
            this._LocationContext = LocationContext;
        }

        public async Task DispatchCommandAsync(Guid id)
        {
            var internalCommand = await this._LocationContext.InternalCommands.SingleOrDefaultAsync(x => x.Id == id);

            Type type = Assembly.GetAssembly(typeof(MarkLocationAsWelcomedCommand)).GetType(internalCommand.Type);
            dynamic command = JsonConvert.DeserializeObject(internalCommand.Data, type);

            internalCommand.ProcessedDate = DateTime.UtcNow;

            await this._mediator.Send(command);
        }
    }
}
