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
    public class SubjectsController : Controller    
    {
        private readonly LearningAppDbContext _db;
    
        public SubjectsController(LearningAppDbContext db)    
        {    
            _db = db;
        }
        

        [Authorize]
        [HttpGet]
        [Route("api/v1/classes/{class_id}/subjects")]
        public IActionResult ListOfSubjects([FromRoute] int class_id)
        {
            // To get the student id from jwt token
            var currentUser = HttpContext.User;
            
            var StudentIdFromJWT = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            int StudentId = Int32.Parse(StudentIdFromJWT);
            
            var SubList = _db.Subjects.Where(s => s.ClassId == class_id).ToList();
            
            List<Subject> ListOfSubjects = new List<Subject>();
            
            for (var i = 0; i < SubList.Count; i++)
            {
                Subject responseObj = new Subject(){
                    Id = SubList[i].Id,
                    ClassId = SubList[i].ClassId,
                    Name = SubList[i].SubName,
                    Logo = SubList[i].logo,
                    Percentage = 58
                };

                ListOfSubjects.Add(responseObj);
            }
            string output = JsonConvert.SerializeObject(ListOfSubjects);
            return Ok(output);
        }
    }
}