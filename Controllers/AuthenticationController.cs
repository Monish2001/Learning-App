// using Microsoft.AspNetCore.Authorization;    
// using Microsoft.AspNetCore.Mvc;    
// using System;
// using System.Linq;
// using Learning_App.Data;
// using Learning_App.Models.Serializer;
// using Learning_App.Models;
    
// namespace Learning_App.Controllers    
// {   
//     [Authorize]
//     [ApiController]    
//     public class AuthenticationController : Controller    
//     {
//         private readonly LearningAppDbContext _db;
//         private readonly IJwtAuth jwtAuth;

//         public AuthenticationController(IJwtAuth jwtAuth, LearningAppDbContext db)
//         {
//             this.jwtAuth = jwtAuth;
//             _db = db;
//         }
        

//         // [AllowAnonymous]
//         // [HttpPost]
//         // [Route("api/v1/auth")]
//         public IActionResult Authenticate([FromForm]Authentication authentication)

//         {
//             var res = _db.Students.Where(s => s.Id == authentication.StudentId);


//             if (res.Count()==0)
//             {
//                 return NotFound();
//             }

//             var token = jwtAuth.GenerateToken(authentication.StudentId);
//             if (token == null)
//                 return Unauthorized();
//             Sessions s = new Sessions(){
//                 JwtToken = token,
//                 Status = true,
//                 StudentId = authentication.StudentId,
//                 Createdtime = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()
//             };
//             _db.Sessions.Add(s);
//             _db.SaveChanges();

            
//             // AuthenticationResponse obj = new AuthenticationResponse();
//             // return Ok(obj.response(token));
//             return Ok(token);
//         }
//     }
// }    
    