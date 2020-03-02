using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Main.ViewModels.ResponseModel
{
    public class ViewModelResponse<T>
    {
        public T Data { get; set; }
        public string Uri { get; set; }
        public string ErrorMessage  { get; set; }
        public string ErrorCode { get; set; }
        public bool Success { get; set; }
    }
}
