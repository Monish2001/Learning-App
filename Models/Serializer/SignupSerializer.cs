using System.ComponentModel.DataAnnotations;

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

    public class SignupResponse
    {
        public string message;
        public int otp_id;
    }
    
    // public class SignupResponseResult{
    //     public SignupResponse sign_up{get; set;}

    //     public SignupResponse result(OTP OtpObj){
    //         SignupResponse res = new SignupResponse
    //         {
    //             message = sign_up.message;
    //             otp_id = OtpObj.Id;
    //         }
    //         return res;
    //     }
    // }

    

}