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
            // Debug.WriteLine("inside signup");
            OTP OtpObj = GenerateOTP();
            int OtpId = OtpObj.Id;

            Console.WriteLine(OtpId);
            // Debug.WriteLine(OtpId);
            // s_r.OtpId = OtpId;
            Students s = s_r.createStudentObject();
            // s.OtpId = OtpId;
            // s.Otp.Id = OtpId;
            // Console.WriteLine(s.Otp.Id);
            _db.Students.Add(s);
            _db.SaveChanges();

            string strng1 = string.Format("Success");
            return Ok(strng1);
        }

        public OTP GenerateOTP()
        {
            // System.Guid OTPuuid = System.Guid.NewGuid();
            // string OTPuuidAsString = OTPuuid.ToString();
            // Debug.WriteLine("inside otp gene");
            // RandomNumber rn = null;
            RandomNumber rn = new RandomNumber();
            int Otp = rn.GenerateRandomNo();

            // DateTime GeneratedTime = DateTime(2000-08-09 00:00:00);
            // DateTime GeneratedTime = new DateTime(2000, 08, 08, 00, 00, 00);
            // DateTime hardcodeValue = new DateTime(yearInt, monthInt, dayInt, hourInt, minuteInt, secondInt);
            long Generatedtime = 1633973956;
            // OTPs OtpObj = new OTPs();
            
            

            // OTPs OtpObj = new OTPs();

            // OtpObj.Id = OTPuuidAsString;
            // OtpObj.Otp = Otp;
            // OtpObj.Generatedtime = Generatedtime;

            // OtpRequestRoot OtpObj = new OtpRequestRoot();

            var OtpObj = new OTP
            {
                Otp = Otp,
                Generatedtime = Generatedtime
            };

            // string jsonString = JsonSerializer.Serialize(OtpObj);
            // string jsonString = JsonConvert.SerializeOnbject(OtpObj);
            // JObject json = JObject.Parse(jsonString);
            // OtpRequestRoot o = OtpRequestRoot.createOTP();

            _db.OTP.Add(OtpObj);
            _db.SaveChanges();

            return OtpObj;
        }
    }
}