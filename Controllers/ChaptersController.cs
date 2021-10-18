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
            
            var studentIdFromJWT = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            int studentId = Int32.Parse(studentIdFromJWT);
            
            var chapterList = _db.Chapters.Where(c => c.SubjectId == sub_id).ToList();
            
            List<Chapter> ListOfChapters = new List<Chapter>();
            
            for (var i = 0; i < chapterList.Count; i++)
            {
                Chapter responseObj = new Chapter(){
                    Id = chapterList[i].Id,
                    Name = chapterList[i].Name,
                    SubjectId = chapterList[i].SubjectId
                };

                ListOfChapters.Add(responseObj);
            }
            ListChaptersResponse chapterResponseObj = new ListChaptersResponse(){
                Chapters = ListOfChapters
            };
            string output = JsonConvert.SerializeObject(chapterResponseObj);
            return Ok(output);
        }
    }
}