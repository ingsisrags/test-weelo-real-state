using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using Utilities.Core.Interfaces.Audilog;

namespace Utilities.Core.Interfaces.Repositories
{
    public interface IRepositoryDbContext : IDisposable,
        IInfrastructure<IServiceProvider>,
        IDbContextDependencies,
        IDbSetCache,
        IDbContextPoolable
    {
        IAuditLogInfo AuditLogInfo { get; set; }
        IEntityHistoryHelper EntityHistoryHelper { get; set; }
    }
}
