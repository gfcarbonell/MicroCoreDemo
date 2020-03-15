using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Core.Api.Main.ViewModels.RequestModel.UserAuthentication;
using Core.Api.Main.ViewModels.ResponseModel;
using Core.CrossCutting.Constants;
using Core.Domain.Models;
using Core.Service.Contract.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Core.Api.Main.Controllers
{
    /// <summary>
    /// Authentication 
    /// </summary>
    [Route("api/auth")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class UserAuthenticationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly ISessionService _sessionService;
        private readonly IJwtTokenService _jwtTokenService;

        /// <summary>
        /// Injection Dependency
        /// </summary>
        public UserAuthenticationController(
            IMapper mapper,
            IConfiguration configuration,
            ISessionService sessionService, 
            IUserService userService,
            IJwtTokenService jwtTokenService)
        {
            _mapper = mapper;
            _configuration = configuration;
            _sessionService = sessionService;
            _userService = userService;
            _jwtTokenService = jwtTokenService;
        }

        /// <summary>
        /// Login by username
        /// </summary>
        /// <param name="login"></param>
        [HttpPost("login/username")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginByUsernameAsync([FromBody] LoginByUsernameViewModelRequest login)
        {
            ViewModelResponse<LoginViewModelResponse> viewModelResponse = new ViewModelResponse<LoginViewModelResponse>()
            {
                Success = false,
                ErrorMessage = string.Empty,
                ErrorCode = string.Empty
            };

            User user = null;
            JwtToken jwtToken = null;
            string name = string.Empty;
            string role = string.Empty;
            string issuer = string.Empty;
            string audience = string.Empty;
            string key = string.Empty;
            int expires = 0;

            try
            {
                // Get user by username and password
                user = await _userService.GetByUsernameAsync(login.Username, login.Password);

                // Validate if the user exists
                if (user == null)
                {
                    viewModelResponse.ErrorMessage = CoreConstant.MESSAGE_USERNAME_PASSWORD_INVALID;
                    viewModelResponse.ErrorCode = CoreConstant.CODE_USERNAME_PASSWORD_INVALID;
                    return BadRequest(viewModelResponse);
                }

                // Set values for create token
                name = user.Username;
                role = user.UserRoles.FirstOrDefault().Role.Denomination;
                issuer = _configuration["Tokens:Issuer"];
                audience = _configuration["Tokens:Issuer"];
                key = _configuration["JWT:Key"];
                expires = int.Parse(_configuration["Jwt:Expires"]);

                // Get token
                jwtToken = await _jwtTokenService.GenerateTokenAsync(name, role, issuer, audience, expires, key);
               
                if(jwtToken == null)
                {
                    viewModelResponse.ErrorMessage = CoreConstant.MESSAGE_TOKEN_INVALID;
                    viewModelResponse.ErrorCode = CoreConstant.CODE_TOKEN_INVALID;
                    return BadRequest(viewModelResponse);
                }

                await _jwtTokenService.AddAsync(jwtToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(viewModelResponse);
        }

        /// <summary>
        /// Token Refresh
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="RefreshToken"></param>
        [HttpPost("token-refresh")]
        public IActionResult TokenRefresh(string Token, string RefreshToken)
        {
            return null;
        }
    }
}