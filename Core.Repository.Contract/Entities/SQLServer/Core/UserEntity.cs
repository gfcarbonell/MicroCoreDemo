using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository.Contract.Entities.SQLServer.Core
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
    }
}
