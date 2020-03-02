using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Models
{
    public class Session
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int JwtTokenId { get; set; }
        public int Code { get; set; }
        public string Captcha { get; set; }
        public string ReCaptcha { get; set; }
        public DateTime LoginDate { get; set; }
        public DateTime LogoutDate { get; set; }
        public int statusId { get; set; }
        public virtual User User { get; set; }
        public virtual JwtToken JwtToken { get; set; }
    }
}
