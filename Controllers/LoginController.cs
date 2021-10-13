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
using Learning_App.Data;
using Learning_App.Models;
using Learning_App.Utils;
    
namespace Learning_App.Controllers    
{   
    // [Authorize]
    // [ApiController]    
    public class LoginController : Controller    
    {
        private readonly LearningAppDbContext _db;
    
        public LoginController(LearningAppDbContext db)    
        {    
            // _config = config;
            _db = db;
        }
        

        [HttpPost]
        [Route("api/v1/login")]
        public IActionResult POST([FromForm]Login login)
        {
            var res = _db.Students.Where(l => l.MobileNo == login.MobileNo);
            var student_id = res.Select(r => r.Id).ToArray();
            Students s = new Students{
                Id = student_id[0]
            };
            GenerateOTP gOtp = new GenerateOTP();
            OTP OtpObj = gOtp.GenerateOtp(s,_db);

            LoginResponse responseObj = new LoginResponse(){
                message = "Otp Generated",
                otp_id = OtpObj.Id
            };
            return Ok(responseObj.otp_id);
        }

        // [HttpPost]
        // [Route("api/v1/signup")]
        // public IActionResult Signup([FromForm]SignupRequestRoot s_r)    
        // {    
        //     Students s = s_r.createStudentObject();

        //     _db.Students.Add(s);
        //     _db.SaveChanges();
        //     // Console.WriteLine(s.Id);
        //     GenerateOTP gOtp = new GenerateOTP();
        //     OTP OtpObj = gOtp.GenerateOtp(s,_db);
        //     SignupResponse responseObj = new SignupResponse(){
        //         message = "User created successfully",
        //         otp_id = OtpObj.Id
        //     };
        //     return Ok(responseObj.otp_id);
        // }
    }
}