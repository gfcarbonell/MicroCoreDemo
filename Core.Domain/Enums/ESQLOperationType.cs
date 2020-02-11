using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.Domain.Enums
{
    public enum ESQLOperationType
    {
        [Description("")]
        NONE,
        [Description("I")]
        INSERT,
        [Description("U")]
        UPDATE,
        [Description("D")]
        DELETE
    }
}
