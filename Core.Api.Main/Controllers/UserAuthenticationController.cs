using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Core.Api.Main.ViewModels.RequestModel.UserAuthentication;
using Core.CrossCutting.Constants;
using Core.Domain.Security;
using Core.Service.Contract.IServices;
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
        private readonly IUserAuthenticationService _userAuthenticationService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Injection by Dependece
        /// </summary>
        public UserAuthenticationController(IMapper mapper,IUserAuthenticationService userAuthenticationService)
        {
            _mapper = mapper;
            _userAuthenticationService = userAuthenticationService;
        }

        /// <summary>
        /// Login by username
        /// </summary>
        /// <param name="login"></param>
        [HttpPost("login/username")]
        public async Task<IActionResult> LoginByUsername([FromBody] LoginByUsernameViewModelRequest login)
        {
            var mapper = _mapper.Map<Login>(login);
            var result = await _userAuthenticationService.LoginByUsernameAsync(mapper);
            if (result == null)
                return BadRequest(new { message = CoreConstant.MESSAGE_USERNAME_PASSWORD_INVALID });

            return Ok(result);
        }

        /// <summary>
        /// Login by email
        /// </summary>
        /// <param name="login"></param>
        [HttpPost("login/email")]
        public async Task<IActionResult> LoginByEmail([FromBody] LoginByEmailViewModelRequest login)
        {
            var mapper = _mapper.Map<Login>(login);
            var result = await _userAuthenticationService.LoginByEmailAsync(mapper);
            if (result == null)
                return BadRequest(new { message = CoreConstant.MESSAGE_EMAIL_PASSWORD_INVALID });

            return Ok(result);
        }

        /// <summary>
        /// Login by cellphone
        /// </summary>
        /// <param name="login"></param>
        [HttpPost("login/cellphone")]
        public async Task<IActionResult> LoginByCellphone([FromBody] LoginByCellphoneViewModelRequest login)
        {
            var mapper = _mapper.Map<Login>(login);
            var result = await _userAuthenticationService.LoginByCellphoneAsync(mapper);
            if (result == null)
                return BadRequest(new { message = CoreConstant.MESSAGE_CELLPHONE_PASSWORD_INVALID });

            return Ok(result);
        }
    }
}