using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Core.Interfaces.Audilog
{
    public interface IAuditLogInfo
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string TenantId { get; set; }

        public string TenantName { get; set; }

        public DateTime ExecutionTime { get; set; }

        public int ExecutionDuration { get; set; }

        public string ClientId { get; set; }

        public string CorrelationId { get; set; }

        public string ClientIpAddress { get; set; }

        public string ClientName { get; set; }

        public string BrowserInfo { get; set; }

        public string HttpMethod { get; set; }

        public int? HttpStatusCode { get; set; }

        public string Url { get; set; }

        public List<IAuditLogActionInfo> Actions { get; set; }

        public List<Exception> Exceptions { get; }

        public Dictionary<string, object> ExtraProperties { get; }

        public List<IEntityChangeInfo> EntityChanges { get; }

        public List<string> Comments { get; set; }
    }
}
