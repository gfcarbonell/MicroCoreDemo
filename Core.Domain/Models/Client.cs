using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Models
{
    public class Client: Person
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
