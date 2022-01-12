using System;

namespace Riva.Domain.Common
{
    public abstract class AuditableBaseEntity
    {
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}