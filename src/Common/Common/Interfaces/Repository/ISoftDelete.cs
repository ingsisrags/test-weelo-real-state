using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Core.Interfaces.Repositories
{
    public interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
    }
}
