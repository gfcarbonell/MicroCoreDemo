using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Main.ViewModels.ResponseModel
{
    public class EmployeeViewModelResponse
    {
        public virtual PersonViewModelResponse Person { get; set; }
    }
}
