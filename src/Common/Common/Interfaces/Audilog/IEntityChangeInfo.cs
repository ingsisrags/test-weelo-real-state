using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Core.Interfaces.Audilog
{
    public interface IEntityChangeInfo
    {
        public DateTime ChangeTime { get; set; }

        public EntityChangeType ChangeType { get; set; }

        public Guid? EntityTenantId { get; set; }

        public string EntityId { get; set; }

        public string EntityTypeFullName { get; set; }

        public List<IEntityPropertyChangeInfo> PropertyChanges { get; set; }

        public Dictionary<string, object> ExtraProperties { get; }

        public object EntityEntry { get; set; }

        public void Merge(IEntityChangeInfo changeInfo);
    }
}
