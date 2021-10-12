using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Learning_App.Models.Serializer;
using Learning_App.Data;
using Learning_App.Models;
// using Learning_App.Models.Serializer;
using Learning_App.Utils;
// using System.Diagnostics;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using System;


namespace Learning_App.Controllers
{
    public class SignupController : Controller
    {
        // private IConfiguration _config;
        private readonly LearningAppDbContext _db;
    
        public SignupController(LearningAppDbContext db)    
        {    
            // _config = config;
            _db = db;
        }

        [HttpPost]
        [Route("api/signup")]
        public IActionResult Signup([FromForm]SignupRequestRoot s_r)    
        {    
            Students s = s_r.createStudentObject();

            _db.Students.Add(s);
            _db.SaveChanges();
            // Console.WriteLine(s.Id);
            
            OTP OtpObj = GenerateOTP(s);
            SignupResponse responseObj = new SignupResponse(){
                message = "User created successfully",
                otp_id = OtpObj.Id
            };
            return Ok(responseObj.otp_id);
        }

        public OTP GenerateOTP(Students s)
        {
            int StudentId = s.Id;
            RandomNumber rn = new RandomNumber();
            int Otp = rn.GenerateRandomNo();

            // long Generatedtime = 1633973956;
            var Generatedtime = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

            
            var OtpObj = new OTP
            {
                StudentId = StudentId,
                Otp = Otp,
                Generatedtime = Generatedtime
            };

            _db.OTP.Add(OtpObj);
            _db.SaveChanges();

            return OtpObj;
        }
    }
}