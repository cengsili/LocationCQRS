using System;
using System.Threading.Tasks;

namespace Location.Service.Infrastructure.Processing
{
    public interface ICommandsDispatcher
    {
        Task DispatchCommandAsync(Guid id);
    }
}
