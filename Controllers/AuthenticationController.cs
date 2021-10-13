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
using Learning_App.Data;
using Learning_App.Models.Serializer;
using Learning_App.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
    
namespace Learning_App.Controllers    
{   
    [Authorize]
    [ApiController]    
    public class AuthenticationController : Controller    
    {
        private readonly LearningAppDbContext _db;
        private readonly IJwtAuth jwtAuth;

        public AuthenticationController(IJwtAuth jwtAuth, LearningAppDbContext db)
        {
            this.jwtAuth = jwtAuth;
            _db = db;
        }
        

        [AllowAnonymous]
        [HttpPost]
        [Route("api/v1/auth")]
        public IActionResult Authenticate([FromForm]Authentication authentication)

        {
            var res = _db.Students.Where(s => s.Id == authentication.StudentId);


            if (res.Count()==0)
            {
                return NotFound();
            }

            var token = jwtAuth.GenerateToken(authentication.StudentId);
            if (token == null)
                return Unauthorized();
            Sessions s = new Sessions(){
                JwtToken = token,
                Status = true,
                StudentId = authentication.StudentId,
                Createdtime = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()
            };
            _db.Sessions.Add(s);
            _db.SaveChanges();

            
            // AuthenticationResponse obj = new AuthenticationResponse();
            // return Ok(obj.response(token));
            return Ok(token);
        }
    }
}    
    