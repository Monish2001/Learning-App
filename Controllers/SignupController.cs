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
        [Route("api/v1/signup")]
        public IActionResult Signup([FromForm]SignupRequestRoot s_r)    
        {    
            Students s = s_r.createStudentObject();

            _db.Students.Add(s);
            _db.SaveChanges();
            // Console.WriteLine(s.Id);
            GenerateOTP gOtp = new GenerateOTP();
            OTP OtpObj = gOtp.GenerateOtp(s,_db);
            SignupResponse responseObj = new SignupResponse(){
                message = "User created successfully",
                otp_id = OtpObj.Id
            };
            return Ok(responseObj.otp_id);
        }
    }
}