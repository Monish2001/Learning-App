using Microsoft.AspNetCore.Authorization;    
using Microsoft.AspNetCore.Mvc;    
using Microsoft.Extensions.Configuration;    
using Microsoft.IdentityModel.Tokens;    
using System;    
using System.IdentityModel.Tokens.Jwt;    
using System.Security.Claims;    
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learning_App.Models.Serializer;
    
namespace Learning_App.Controllers    
{   
    [Authorize]
    [ApiController]    
    public class AuthenticationController : Controller    
    {
        private readonly IJwtAuth jwtAuth;

        public AuthenticationController(IJwtAuth jwtAuth)
        {
            this.jwtAuth = jwtAuth;
        }
        

        [AllowAnonymous]
        [HttpPost]
        [Route("api/v1/login")]
        public IActionResult POST([FromForm]Authentication authentication)
        {
            var token = jwtAuth.GenerateToken(authentication.MobileNo, authentication.Otp);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}    
    