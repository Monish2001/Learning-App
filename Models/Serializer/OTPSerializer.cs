using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;  
// using System.Web.Script.Serialization;
using Microsoft.AspNetCore.Mvc;
using Learning_App.Models;
using Learning_App.Data;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace Learning_App.Models.Serializer
{
    public class OTPs
    {
        [Required]
        public int Id {get; set;}
        [Required]
        public int Otp {get; set;}
        
    }

    public class OtpRequestRoot{
        public OTPs Obj {get; set;}

        public OTP OtpObj(LearningAppDbContext _db)
        {
            
            OTP o = new OTP
            {
                Otp = Obj.Otp,
                Id = Obj.Id,
            };
            var res = _db.OTP.Where(r => r.Id == o.Id && r.Otp == o.Otp);
            // Console.WriteLine(res.Count());
            if(res.Count()==0)
            {
                return null;
            }
            var student_id = res.Select(r => r.StudentId).ToArray();
            var generated_time = res.Select(r => r.Generatedtime).ToArray();
            o.StudentId = student_id[0];
            o.Generatedtime = generated_time[0];
            return o;
        }   
    }
}