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
        public string Jti { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime Expires { get; set; }
        public DateTime NotBefore { get; set; }
        public string RefreshToken { get; set; }
        public int StatusId { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
