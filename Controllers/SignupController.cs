using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Learning_App.Models.Serializer;
using Learning_App.Data;
using Learning_App.Models;
using Learning_App.Utils;
using System.Diagnostics;

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
            // OTP OtpObj = GenerateOTP();
            // string OtpId = OtpObj.Id;
            Students s = s_r.createStudentObject();
            // s.OtpId = OtpId;
            _db.Students.Add(s);
            _db.SaveChanges();

            string strng1 = string.Format("Success");
            return Ok(strng1);
        }

        // public void GenerateOTP()
        // {
        //     System.Guid OTPuuid = System.Guid.NewGuid();
        //     string OTPuuidAsString = OTPuuid.ToString();
            
        //     RandomNumber rn = null;
        //     int Otp = rn.GenerateRandomNo();

        //     DateTime GeneratedTime = "2000-08-09 00:00:00";

        //     OTP OtpObj = new OTP();

        //     OtpObj.Id = OTPuuidAsString;
        //     OtpObj.Otp = Otp;
        //     OtpObj.GeneratedTime = GeneratedTime;

        //     _db.OTP.Add(OtpObj);
        //     _db.SaveChanges();

        //     return OtpObj;
        // }
    }
}