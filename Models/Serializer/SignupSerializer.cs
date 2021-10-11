using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Mvc;


namespace Learning_App.Models.Serializer
{
    public class Signup
    {
        public string Id {get; set;}
        [Required]
        public string FullName {get; set;}
        [Required]
        public string MobileNo {get; set;}
        [Required]
        public string Email {get; set;}
        [Required]
        // public DateTime DOB {get; set;}
        public long Dob {get; set;}
        // public int OtpId {get; set;}
        
    }

    public class SignupRequestRoot{
        public Signup sign_up {get; set;}

        public Students createStudentObject()
        {
            Students s = new Students
            {
                Email = sign_up.Email,
                MobileNo = sign_up.MobileNo,
                FullName = sign_up.FullName,
                Dob = sign_up.Dob,
                // OtpId = sign_up.Otp.OtpId
            };
            return s;
        }
    }

    

}