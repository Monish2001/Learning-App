using Microsoft.AspNetCore.Authorization;    
using Microsoft.AspNetCore.Mvc;      
using System;    
using System.Security.Claims;    
using System.Collections.Generic;
using System.Linq;
using Learning_App.Data;
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
            
            var studentIdFromJWT = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            int studentId = Int32.Parse(studentIdFromJWT);

            var boardIdFromDb = _db.StudentEnrollments.Where(b => b.StudentId == studentId).ToList();

            int boardId = boardIdFromDb[0].BoardId;
            
            var classList = _db.Classes.Where(c => c.BoardId == boardId).ToList();
            
            List<Class> ListOfClasses = new List<Class>();
            
            for (var i = 0; i < classList.Count; i++)
            {
                Class responseObj = new Class(){
                    Id = classList[i].Id,
                    Title = classList[i].Title
                };

                ListOfClasses.Add(responseObj);
            }
            ListClassesResponse classResponseObj = new ListClassesResponse(){
                Classes = ListOfClasses
            };
            string output = JsonConvert.SerializeObject(classResponseObj);
            return Ok(output);
        }

        [Authorize]
        [HttpPut]
        [Route("api/v1/classes")]
        public IActionResult SelectClass([FromForm] ClassResquest classObj)
        {
            // To get the student id from jwt token
            var currentUser = HttpContext.User;
            
            var studentIdFromJWT = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            int studentId = Int32.Parse(studentIdFromJWT);

            
            int classId = classObj.Id;

            // Update classId in students table
            var student = _db.Students.Where(s => s.Id == studentId).ToList();
            student.ForEach(s => s.ClassId = classId);
            _db.SaveChanges();
            
            
            var classDetails = _db.Classes.Where(c => c.Id == classId).ToList();

            Class responseObj = new Class(){
                    Id = classDetails[0].Id,
                    Title = classDetails[0].Title
            };
            PostClassResponse classResponseObj = new PostClassResponse(){
                Class = responseObj
            };
            string output = JsonConvert.SerializeObject(classResponseObj);
            return Ok(output);
            
        }
    }
}