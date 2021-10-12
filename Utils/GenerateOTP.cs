using System;
using Learning_App.Data;
using Learning_App.Models;
using Learning_App.Utils;


namespace Learning_App.Utils
{
    public class GenerateOTP{
        public OTP GenerateOtp(Students s, LearningAppDbContext _db)
        {
            int StudentId = s.Id;
            RandomNumber rn = new RandomNumber();
            int Otp = rn.GenerateRandomNo();

            // long Generatedtime = 1633973956;
            var Generatedtime = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

            
            var OtpObj = new OTP
            {
                StudentId = StudentId,
                Otp = Otp,
                Generatedtime = Generatedtime
            };

            _db.OTP.Add(OtpObj);
            _db.SaveChanges();

            return OtpObj;

            // OTP OtpObj = new OTP
            //     {
            //         StudentId = StudentId,
            //         Otp = Otp,
            //         Generatedtime = Generatedtime
            //     };

            // var res = _db.OTP.Where(r => r.StudentId == OtpObj.StudentId);
            // if(res.Count()==0){
                

            //     _db.OTP.Add(OtpObj);
            //     _db.SaveChanges();
            //     return OtpObj;
            // }
            // else{
            //     res.Otp = Otp;
            //     _db.SaveChanges();
            //     return OtpObj;
            // }

        }
    }
}


