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
        public string message;
        public int otp_id;
    }
}