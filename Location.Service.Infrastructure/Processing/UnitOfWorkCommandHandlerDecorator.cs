using Location.Service.Application.Configuration.Commands;
using Location.Service.Domain;
using Location.Service.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Location.Service.Infrastructure.Processing
{
    public class UnitOfWorkCommandHandlerDecorator<T> : ICommandHandler<T> where T : ICommand
    {
        private readonly ICommandHandler<T> _decorated;

        private readonly ILocationUnitOfWork _unitOfWork;

        private readonly LocationContext _locationContext;

        public UnitOfWorkCommandHandlerDecorator(
            ICommandHandler<T> decorated,
            ILocationUnitOfWork unitOfWork,
            LocationContext locationContext)
        {
            _decorated = decorated;
            _unitOfWork = unitOfWork;
            _locationContext = locationContext;
        }

        public async Task<Unit> Handle(T command, CancellationToken cancellationToken)
        {
            await this._decorated.Handle(command, cancellationToken);

            if (command is InternalCommandBase)
            {
                var internalCommand =
                    await _locationContext.InternalCommands.FirstOrDefaultAsync(x => x.Id == command.Id,
                        cancellationToken: cancellationToken);

                if (internalCommand != null)
                {
                    internalCommand.ProcessedDate = DateTime.UtcNow;
                }
            }

            await this._unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
