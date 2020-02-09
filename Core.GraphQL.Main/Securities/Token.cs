using Core.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.GraphQL.Main.Securities
{
    public class Token
    {
        protected readonly IConfiguration _configuration;

        public Token(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //public bool ValidarToken(string refreshToken)
        //{
        //    var tokenGuardado = contexto.UsuarioAcceso
        //            .FirstOrDefault(u => u.RefreshToken == refreshToken
        //                            && u.Activo);
        //    //No existe marcamos error
        //    if (tokenGuardado == null)
        //        return false;
        //    //Revisamos que el usuario este activo
        //    var usuario = contexto.Usuario.Find(tokenGuardado.UsuarioId);
        //    if (usuario == null || !usuario.Activo)
        //        return false;
        //    tokenDTO = GenerarToken(usuario;
        //    return true;
        //}

        public string RefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber)
                        .Replace("$", "1").Replace("/", "2")
                        .Replace("&", "3").Replace("+", "4")
                        .Replace("-", "5").Replace("?", "6");
            }
        }
        public async Task<string> GenerateToken(User user)
        {
            string Issuer = _configuration["Tokens:Issuer"];            
            string Audience = _configuration["Tokens:Issuer"];
            string Key = _configuration["JWT:Key"];

            DateTime IssuedAt = DateTime.UtcNow;
            DateTime NotBefore = IssuedAt;
            DateTime Expires = IssuedAt.AddMinutes(int.Parse(_configuration["Jwt:Expires"]));

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.UserRoles.FirstOrDefault().Role.Denomination),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, IssuedAt.ToString(), ClaimValueTypes.Integer),
                new Claim(JwtRegisteredClaimNames.Exp, Expires.ToString(), ClaimValueTypes.Integer),

                //new Claim(JwtRegisteredClaimNames.Iss, Issuer),
                //new Claim(JwtRegisteredClaimNames.Aud, Audience),
            };

            ClaimsIdentity Subject = new ClaimsIdentity(claims);

            SymmetricSecurityKey SymmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Expires.ToString()));
            SigningCredentials SigningCredentials = new SigningCredentials(SymmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = Issuer,            
                Audience = Audience,       
                IssuedAt = IssuedAt,
                NotBefore = NotBefore,
                Expires = Expires,
                Subject = Subject,
                SigningCredentials = SigningCredentials
            };

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtTokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            var token = jwtTokenHandler.WriteToken(jwtToken);
            return await Task.Run(() => token);
        }
    }
}
