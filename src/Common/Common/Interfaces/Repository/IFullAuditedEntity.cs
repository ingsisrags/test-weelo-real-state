using System;

namespace Utilities.Core.Interfaces.Repositories
{
    public interface IFullAuditedEntity
    {
        public bool IsDeleted { get; set; }

        public string? DeleterUserId { get; set; }

        public DateTime? DeletionTime { get; set; }
    }
}
