using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Location.Service.Application.Configuration
{
    public interface IExecutionContextAccessor
    {
        Guid CorrelationId { get; }

        bool IsAvailable { get; }
    }
}
