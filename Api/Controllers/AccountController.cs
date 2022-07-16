using Application.Contracts.Authentication;
using Application.Models.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            try
            {
                return Ok(await _authenticationService.AuthenticateAsync(request));
            }
            catch(Exception e)
            {
                return new AuthenticationResponse() { Id = e.Message, Email = e.Message, Token = e.ToString(), UserName = e.GetType().ToString() };
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegistrationRequest request)
        {
            try
            {
                return Ok(await _authenticationService.RegisterAsync(request));
            }
            catch (Exception e)
            {
                return new RegistrationResponse() { UserId = "null" };
            }
            
        }
    }
}
