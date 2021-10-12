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
    public class OTPVerification : Controller
    {
        private readonly LearningAppDbContext _db;
    
        public OTPVerification(LearningAppDbContext db)    
        {    
            _db = db;
        }

        [HttpPost]
        [Route("api/v1/otp-verification")]
        public IActionResult OtpVerification([FromForm]OtpRequestRoot o_r)    
        {    
            OTP OtpObj = o_r.OtpObj(_db);
            
            if(OtpObj == null)
            {
                var result = new NotFoundObjectResult(new { message = "404 Not Found"});
                return result;
            }
        
            return Ok(OtpObj);
        }

    }
}