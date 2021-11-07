using Common.Utilities.Database;
using System;
using Utilities.Core.Interfaces.Repositories;

namespace Utilities.Core.Configuration.Database.Models
{
    public abstract class CreationAuditedEntity<TPrimaryKey> : Entity<TPrimaryKey>, ICreationAuditedEntity
    {
        public virtual DateTime CreationTime { get; set; }

        public virtual string? CreatorUserId { get; set; }

        protected CreationAuditedEntity()
        {
            CreationTime = DateTime.Now;
        }
    }
}
