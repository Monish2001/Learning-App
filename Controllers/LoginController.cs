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
    public class LoginController : Controller    
    {
        private readonly IJwtAuth jwtAuth;

        public LoginController(IJwtAuth jwtAuth)
        {
            this.jwtAuth = jwtAuth;
        }
        

        [AllowAnonymous]
        [HttpPost]
        [Route("api/members/login")]
        public IActionResult POST([FromForm]Login login)
        {
            var token = jwtAuth.Authentication(login.MobileNo, login.Otp);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}    
    