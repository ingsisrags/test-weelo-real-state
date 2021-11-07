using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Core.Interfaces.Repositories
{
    public interface IAuditedEntity
    {
        public DateTime? LastModificationTime { get; set; }

        public string? LastModifierUserId { get; set; }
    }
}
