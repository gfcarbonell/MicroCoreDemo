﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string MotherLastName { get; set; }
        public string EMail { get; set; }
    }
}
