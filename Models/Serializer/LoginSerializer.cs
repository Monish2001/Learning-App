using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace Learning_App.Models.Serializer
{
    public class Login
    {
        [Required]
        public string MobileNo {get; set;}
        [Required]
        public int Otp {get; set;}
    }

}