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