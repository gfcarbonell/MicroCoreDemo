using Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Models.Generic
{
    public abstract class Audit
    {
        public bool Actived { get; set; }
        bool Deleted { get; set; }
        ESQLOperationType LastOperation { get; set; }
        int CreatedByUserId { get; set; }
        DateTime CreatedDate { get; set; }
        string CreatedByHostname { get; set; }
        string CreatedByIPAddress { get; set; }
        int? ModifiedByUserId { get; set; }
        DateTime? ModificationDate { get; set; }
        string ModifiedByHostname { get; set; }
        string ModifiedByIPAddress { get; set; }
    }
}
