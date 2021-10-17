using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Learning_App.Models.Serializer;
using Learning_App.Data;
using Learning_App.Models;
using Learning_App.Utils;
using Newtonsoft.Json;
 
namespace Learning_App.Controllers    
{   
    // [Authorize]
    // [ApiController]    
    public class LoginController : Controller    
    {
        private readonly LearningAppDbContext _db;
    
        public LoginController(LearningAppDbContext db)    
        {    
            // _config = config;
            _db = db;
        }
        

        [HttpPost]
        [Route("api/v1/login")]
        public IActionResult POST([FromForm]Login login)
        {
            var res = _db.Students.Where(l => l.MobileNo == login.MobileNo);
            var student_id = res.Select(r => r.Id).ToArray();
            Students s = new Students{
                Id = student_id[0]
            };
            GenerateOTP gOtp = new GenerateOTP();
            OTP OtpObj = gOtp.GenerateOtp(s,_db);

            LoginResponse responseObj = new LoginResponse(){
                Message = "Otp Generated",
                OtpId = OtpObj.Id
            };
            string output = JsonConvert.SerializeObject(responseObj);
            return Ok(output);
        }

        // [HttpPost]
        // [Route("api/v1/signup")]
        // public IActionResult Signup([FromForm]SignupRequestRoot s_r)    
        // {    
        //     Students s = s_r.createStudentObject();

        //     _db.Students.Add(s);
        //     _db.SaveChanges();
        //     // Console.WriteLine(s.Id);
        //     GenerateOTP gOtp = new GenerateOTP();
        //     OTP OtpObj = gOtp.GenerateOtp(s,_db);
        //     SignupResponse responseObj = new SignupResponse(){
        //         message = "User created successfully",
        //         otp_id = OtpObj.Id
        //     };
        //     return Ok(responseObj.otp_id);
        // }
    }
}