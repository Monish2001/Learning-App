using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace Learning_App.Models.Serializer
{
    public class Authentication
    {
        [Required]
        public int StudentId {get; set;}
    }

    public class AuthenticationResponseRoot
    {
        // public string message;
        public string authentication;

    }

    public class AuthenticationResponse{
        public AuthenticationResponseRoot auth {get; set;}

        public AuthenticationResponseRoot response(string token)
        {
            AuthenticationResponseRoot s = new AuthenticationResponseRoot
            {
                authentication = token
                // OtpId = sign_up.Otp.OtpId
            };
            return s;
        }
    }




}