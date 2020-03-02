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
        private readonly IUserService _userService;
        private readonly ISessionService _sessionService;
        /// <summary>
        /// Injection Dependency
        /// </summary>
        public UserAuthenticationController(IMapper mapper, ISessionService sessionService, IUserService userService)
        {
            _mapper = mapper;
            _sessionService = sessionService;
            _userService = userService;
        }

        /// <summary>
        /// Login by username
        /// </summary>
        /// <param name="login"></param>
        [HttpPost("login/username")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginByUsernameAsync([FromBody] LoginByUsernameViewModelRequest login)
        {
            ViewModelResponse<LoginViewModelResponse> viewModelResponse = new ViewModelResponse<LoginViewModelResponse>();
            User user = await _userService.GetByUsernameAsync(login.Username, login.Password);
            if (user == null)
            {
                viewModelResponse.ErrorMessage = CoreConstant.MESSAGE_USERNAME_PASSWORD_INVALID;
                viewModelResponse.ErrorCode = CoreConstant.CODE_USERNAME_PASSWORD_INVALID;
                return BadRequest(viewModelResponse);
            }

            var session = new Session()
            {
                UserId = user.Id, 
                Captcha = login.Captcha, 
                ReCaptcha = login.ReCaptcha
            };

            await _sessionService.AddAsync(session);
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