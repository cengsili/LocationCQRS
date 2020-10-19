using System;
using System.Threading;
using System.Threading.Tasks;
using Location.Service.Application.Configuration.Commands;
using Location.Service.Domain;
using Location.Service.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;



namespace Location.Service.Infrastructure.Processing
{
    public class UnitOfWorkCommandHandlerWithResultDecorator<T, TResult> : ICommandHandler<T, TResult> where T : ICommand<TResult>
    {
        private readonly ICommandHandler<T, TResult> _decorated;

        private readonly ILocationUnitOfWork _unitOfWork;

        private readonly LocationContext _locationContext;

        public UnitOfWorkCommandHandlerWithResultDecorator(
            ICommandHandler<T, TResult> decorated,
            ILocationUnitOfWork unitOfWork,
            LocationContext locationContext)
        {
            _decorated = decorated;
            _unitOfWork = unitOfWork;
            _locationContext = locationContext;
        }

        public async Task<TResult> Handle(T command, CancellationToken cancellationToken)
        {
            var result = await this._decorated.Handle(command, cancellationToken);

            if (command is InternalCommandBase<TResult>)
            {
                var internalCommand = await _locationContext.InternalCommands.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

                if (internalCommand != null)
                {
                    internalCommand.ProcessedDate = DateTime.UtcNow;
                }
            }

            await this._unitOfWork.CompleteAsync();

            return result;
        }
    }
}
