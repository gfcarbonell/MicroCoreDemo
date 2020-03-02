using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Main.ViewModels.ResponseModel
{
    public class PersonViewModelResponse
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string MotherLastName { get; set; }
        public string EMail { get; set; }
    }
}
