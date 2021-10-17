using System.ComponentModel.DataAnnotations;

namespace Learning_App.Models.Serializer
{
    public class Login
    {
        [Required]
        public string MobileNo {get; set;}
    }

    public class LoginResponse
    {
        public string Message;
        public int OtpId;
    }
}