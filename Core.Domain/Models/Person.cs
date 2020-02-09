using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Models
{
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string MotherLastName { get; set; }
        public string EMail { get; set; }
    }
}
