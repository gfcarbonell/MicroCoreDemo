using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost]
        public Task<IActionResult> Refresh(string token, string refreshToken)
        {
            //var principal = GetPrincipalFromExpiredToken(token);
            //var username = principal.Identity.Name;
            //var savedRefreshToken = GetRefreshToken(username); //retrieve the refresh token from a data store
            //if (savedRefreshToken != refreshToken)
            //    throw new SecurityTokenException("Invalid refresh token");

            //var newJwtToken = GenerateToken(principal.Claims);
            //var newRefreshToken = GenerateRefreshToken();
            //DeleteRefreshToken(username, refreshToken);
            //SaveRefreshToken(username, newRefreshToken);

            //return new ObjectResult(new
            //{
            //    token = newJwtToken,
            //    refreshToken = newRefreshToken
            //});
            return null;
        }
    }
}