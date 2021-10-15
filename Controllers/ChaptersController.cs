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
    public class ChaptersController : Controller    
    {
        private readonly LearningAppDbContext _db;
    
        public ChaptersController(LearningAppDbContext db)    
        {    
            _db = db;
        }
        

        [Authorize]
        [HttpGet]
        [Route("api/v1/classes/{class_id}/subjects/{sub_id}/chapters")]
        public IActionResult ListOfChapters([FromRoute] int class_id, [FromRoute] int sub_id)
        {
            // To get the student id from jwt token
            var currentUser = HttpContext.User;
            
            var StudentIdFromJWT = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            int StudentId = Int32.Parse(StudentIdFromJWT);
            
            var ChapterList = _db.Chapters.Where(c => c.SubjectId == sub_id).ToList();
            
            List<Chapter> ListOfChapters = new List<Chapter>();
            
            for (var i = 0; i < ChapterList.Count; i++)
            {
                Chapter responseObj = new Chapter(){
                    Id = ChapterList[i].Id,
                    Name = ChapterList[i].Name,
                    SubjectId = ChapterList[i].SubjectId
                };

                ListOfChapters.Add(responseObj);
            }
            string output = JsonConvert.SerializeObject(ListOfChapters);
            return Ok(output);
        }
    }
}