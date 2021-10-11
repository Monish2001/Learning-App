using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Mvc;


namespace Learning_App.Models.Serializer
{
    public class OTP
    {
        public string Id {get; set;}
        [Required]
        public int Otp {get; set;}
        [Required]
        public DateTime GeneratedTime {get; set;}

        
    }

    public class OtpRequestRoot{
        // public Signup sign_up {get; set;}

        public OTP createOTP(OTP OtpObj)
        {
            OTP o = new OTP
            {
                Id = OtpObj.Id,
                Otp = OtpObj.Otp,
                GeneratedTime = OtpObj.GeneratedTime
            };
            return o;
        }
        
    }

    

}