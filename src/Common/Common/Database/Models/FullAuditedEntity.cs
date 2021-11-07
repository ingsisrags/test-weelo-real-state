using System;
using Utilities.Core.Interfaces.Repositories;

namespace Utilities.Core.Configuration.Database.Models
{
    public abstract class FullAuditedEntity<TPrimaryKey> : AuditedEntity<TPrimaryKey>, ISoftDelete, IFullAuditedEntity
    {
        public virtual bool IsDeleted { get; set; }

        public virtual string? DeleterUserId { get; set; }

        public virtual DateTime? DeletionTime { get; set; }

    }
}
