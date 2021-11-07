using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Utilities.Core.Interfaces.Audilog;
using Utilities.Core.Interfaces.Repositories;

namespace Utilities.Core.Implementation.Database
{
    public class RepositoryDbContext : DbContext, IRepositoryDbContext
    {
        public IAuditLogInfo AuditLogInfo { get; set; }
        public IEntityHistoryHelper EntityHistoryHelper { get; set; }

        public RepositoryDbContext(
            DbContextOptions options
        )
            : base(options)
        {
            //EntityHistoryHelper = NullEntityHistoryHelper.Instance;
            //AuditLogInfo = NullAuditLogInfo.Instance;
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            try
            {
                var auditLog = AuditLogInfo;

                List<IEntityChangeInfo> entityChangeList = null;
                if (auditLog != null)
                {
                    entityChangeList = EntityHistoryHelper.CreateChangeList(ChangeTracker.Entries().ToList());
                }

                var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);

                if (auditLog != null)
                {
                    EntityHistoryHelper.UpdateChangeList(entityChangeList);
                    auditLog.EntityChanges.AddRange(entityChangeList);
                }

                return result;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbUpdateConcurrencyException(ex.Message, ex);
            }
            finally
            {
                ChangeTracker.AutoDetectChangesEnabled = true;
            }
        }
    }
}
