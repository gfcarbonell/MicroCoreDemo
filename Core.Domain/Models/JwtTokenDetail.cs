using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Models
{
    public class JwtTokenDetail
    {
        public int JwtTokenDetailId { get; set; }
        public DateTime RefreshTokenDate { get; set; }
        public DateTime Iat { get; set; }
        public DateTime Exp { get; set; }
    }
}
