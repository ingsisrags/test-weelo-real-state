using System;

namespace Utilities.Core.Interfaces.Audilog
{
    public interface IServiceProviderAccessor
    {
        IServiceProvider ServiceProvider { get; }
    }
}
