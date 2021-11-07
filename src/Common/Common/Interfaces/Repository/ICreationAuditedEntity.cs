using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Core.Interfaces.Repositories
{
    public interface ICreationAuditedEntity
    {
        public DateTime CreationTime { get; set; }

        public string? CreatorUserId { get; set; }
    }
}
