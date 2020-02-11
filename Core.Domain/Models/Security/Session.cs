using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Models.Security
{
    public class Session
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int JwtTokenId { get; set; }
        public int Code { get; set; }
        public DateTime LoginDate { get; set; }
        public DateTime LogoutDate { get; set; }
        public int statusId { get; set; }
        public virtual User User { get; set; }
        public virtual JwtToken JwtToken { get; set; }
    }
}
