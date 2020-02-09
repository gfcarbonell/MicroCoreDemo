using Core.Domain.Models;
using Core.Domain.Models.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Dto
{
    public class UserAuthentication
    {
        public int Code { get; set; }
        public JwtToken JwtToken { get; set; }
        public User User { get; set; }
    }
}
