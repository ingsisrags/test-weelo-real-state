using System;
using Utilities.Core.Interfaces.Repositories;

namespace Utilities.Core.Configuration.Database.Models
{
    public abstract class AuditedEntity<TPrimaryKey> : CreationAuditedEntity<TPrimaryKey>, IAuditedEntity
    {
        public virtual DateTime? LastModificationTime { get; set; }

        public virtual string? LastModifierUserId { get; set; }
    }
}
