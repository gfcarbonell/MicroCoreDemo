using Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Models
{
    public abstract class Audit
    {
        public bool Active { get; set; }
        public bool Delete { get; set; }
        public SQLOperationType LastOperation { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
