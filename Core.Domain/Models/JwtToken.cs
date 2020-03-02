using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Models
{
    public class JwtToken
    {
        public JwtToken()
        {
            this.Sessions = new List<Session>();
        }

        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime Iat { get; set; }
        public DateTime Exp { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenDate { get; set; }
        public int StatusId { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
