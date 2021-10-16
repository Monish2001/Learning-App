using Microsoft.AspNetCore.Mvc;
using Learning_App.Models.Serializer;
using Learning_App.Data;
using Learning_App.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;    

namespace Learning_App.Controllers
{
    public class OTPVerification : Controller
    {
        private readonly LearningAppDbContext _db;
        private readonly IJwtAuth jwtAuth;
    
        public OTPVerification(IJwtAuth jwtAuth, LearningAppDbContext db)    
        {    
            this.jwtAuth = jwtAuth;
            _db = db;
        }

        [HttpPost]
        [Route("api/v1/otp-verification")]
        public IActionResult OtpVerification([FromQuery]OtpRequestRoot o_r)    
        {    
            OTP OtpObj = o_r.OtpRequest(_db);

            
            if(OtpObj == null)
            {
                var result = new NotFoundObjectResult(new { message = "404 Not Found"});
                return result;
            }
            int studentId = OtpObj.StudentId;
            var authResponse = Authenticate(studentId);

            OkObjectResult okResult = (OkObjectResult)authResponse;
            dynamic tokenValue = okResult.Value;

            OtpResponse otpResponseObj = new OtpResponse{
                Message = "OTP Verified Successfully",
                Token = tokenValue
            }; 

            Console.WriteLine(tokenValue);
            return Ok(otpResponseObj);
        }

        [Authorize]
        public IActionResult Authenticate(int studentId)

        {
            var res = _db.Students.Where(s => s.Id == studentId);


            if (res.Count()==0)
            {
                return NotFound();
            }

            var token = jwtAuth.GenerateToken(studentId);
            if (token == null)
                return Unauthorized();
            Sessions s = new Sessions(){
                JwtToken = token,
                Status = true,
                StudentId = studentId,
                Createdtime = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()
            };
            _db.Sessions.Add(s);
            _db.SaveChanges();
            return Ok(token);
        }

    }
}