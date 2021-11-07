using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Core.Interfaces.Audilog
{
    public interface IAuditLogActionInfo
    {
        public string ServiceName { get; set; }

        public string MethodName { get; set; }

        public string Parameters { get; set; }

        public DateTime ExecutionTime { get; set; }

        public int ExecutionDuration { get; set; }

        public Dictionary<string, object> ExtraProperties { get; }
    }
}
