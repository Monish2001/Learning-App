using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using System.Data;


// private readonly LearningAppDbContext _db;
    
//         public SignupController(LearningAppDbContext db)    
//         {    
//             // _config = config;
//             _db = db;
//         }

namespace Learning_App
{
    public class Auth : IJwtAuth
    {
        private readonly string mobileno = "8608319422";
        private readonly int otp = 1234;
        private readonly string key;
        public Auth(string key)
        {
            this.key = key;
        }
        public string GenerateToken(string mobileno, int otp)
        {

            if (!(mobileno.Equals(mobileno) || otp.Equals(otp)))
            {
                return null;
            }

            // 1. Create Security Token Handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // 2. Create Private Key to Encrypted
            var tokenKey = Encoding.ASCII.GetBytes(key);

            //3. Create JETdescriptor
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, mobileno)
                    }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            //4. Create Token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // 5. Return Token from method
            return tokenHandler.WriteToken(token);
        }
    }
}