using Microsoft.AspNetCore.Authorization;    
using Microsoft.AspNetCore.Mvc;    
using Microsoft.Extensions.Configuration;    
using Microsoft.IdentityModel.Tokens;    
using System;    
using System.IdentityModel.Tokens.Jwt;    
using System.Security.Claims;    
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learning_App.Models.Serializer;
using Learning_App.Data;
using Learning_App.Models;
using Learning_App.Utils;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

    
namespace Learning_App.Controllers    
{   
    public class ClassesController : Controller    
    {
        private readonly LearningAppDbContext _db;
    
        public ClassesController(LearningAppDbContext db)    
        {    
            _db = db;
        }
        

        [Authorize]
        [HttpGet]
        [Route("api/v1/classes")]
        public IActionResult ListOfClasses()
        {
            // To get the student id from jwt token
            var currentUser = HttpContext.User;
            
            var StudentIdFromJWT = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            int StudentId = Int32.Parse(StudentIdFromJWT);

            var BoardIdFromDb = _db.StudentEnrollments.Where(b => b.StudentId == StudentId).ToList();

            int BoardId = BoardIdFromDb[0].BoardId;
            
            var classList = _db.Classes.Where(c => c.BoardId == BoardId).ToList();
            
            List<Class> ListOfClasses = new List<Class>();
            
            for (var i = 0; i < classList.Count; i++)
            {
                Class responseObj = new Class(){
                    Id = classList[i].Id,
                    Title = classList[i].Title
                };

                ListOfClasses.Add(responseObj);
            }
            string output = JsonConvert.SerializeObject(ListOfClasses);  
            Console.WriteLine(output);
            return Ok(output);
        }

        [Authorize]
        [HttpPut]
        [Route("api/v1/classes")]
        public IActionResult SelectClass([FromForm] ClassResquest classObj)
        {
            // To get the student id from jwt token
            var currentUser = HttpContext.User;
            
            var StudentIdFromJWT = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            int StudentId = Int32.Parse(StudentIdFromJWT);

            
            int classId = classObj.Id;
            // _db.Students.Where(s => s.Id == StudentId).ToList().Select(s => { s.ClassId = classId;});
            // _db.Students.Where(s => s.Id == StudentId).ToList().SetValue(s => s.ClassId = classId);
            
            // Update classId in students table
            var Student = _db.Students.Where(s => s.Id == StudentId).ToList();
            Student.ForEach(s => s.ClassId = classId);
            _db.SaveChanges();
            
            
            var ClassDetails = _db.Classes.Where(c => c.Id == classId).ToList();

            Class responseObj = new Class(){
                    Id = ClassDetails[0].Id,
                    Title = ClassDetails[0].Title
            };

            string output = JsonConvert.SerializeObject(responseObj);  
            return Ok(output);
        }
    }
}