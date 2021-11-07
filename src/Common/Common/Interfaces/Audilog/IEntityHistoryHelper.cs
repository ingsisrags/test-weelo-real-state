using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Core.Interfaces.Audilog
{
    public interface IEntityHistoryHelper
    {
        List<IEntityChangeInfo> CreateChangeList(ICollection<EntityEntry> entityEntries);

        void UpdateChangeList(List<IEntityChangeInfo> entityChanges);
    }
}
