using Microsoft.AspNetCore.Authorization;    
using Microsoft.AspNetCore.Mvc;    
using System.Collections.Generic;
using System.Linq;
using Learning_App.Data;
using System.Security.Claims;    
using Learning_App.Models;
using Newtonsoft.Json;
using System;

namespace Learning_App.Controllers    
{   
    public class PracticeChapterProgressController : Controller    
    {
        private readonly LearningAppDbContext _db;
    
        public PracticeChapterProgressController(LearningAppDbContext db)    
        {    
            _db = db;
        }
        
        [Authorize]
        [HttpGet]
        [Route("api/v1/subjects/{sub_id}/chapters")]
        public IActionResult PracticeChapterProgress([FromRoute] int sub_id)
        {            
            var currentUser = HttpContext.User;
            
            var studentIdFromJWT = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            int studentId = Int32.Parse(studentIdFromJWT);
            
            var chaptersObj = _db.Chapters.Where(c => c.SubjectId == sub_id).ToList();

            List<ChaptersProgress> listOfChaptersProgress = new List<ChaptersProgress>();
            
            for (var i = 0; i < chaptersObj.Count; i++)
            {
                int id = chaptersObj[i].Id;
                string name = chaptersObj[i].Name;
                int subId = chaptersObj[i].SubjectId;

                int totalExcercise = _db.Excercises.Where(e => e.ChapterId == id).Count();

                ChaptersProgress chapterProgressObj = new ChaptersProgress(){
                    Id = id,
                    Name = name,
                    SubId = subId,
                    TotalExcercise = totalExcercise,
                    CompletionPercentage = CalculateCompletionPercentageOfPracticeChapter(id,studentId)
                };

                listOfChaptersProgress.Add(chapterProgressObj);
            }

            ChapterProgressResponse responseObj = new ChapterProgressResponse(){
                ChapterProgressResponseList = listOfChaptersProgress
            };

            string output = JsonConvert.SerializeObject(responseObj);
            return Ok(output);
        }

        public double CalculateCompletionPercentageOfPracticeChapter(int chapterId, int studentId)
        {
            var excerciseObj = _db.Excercises.Where(e => e.ChapterId == chapterId).ToList();
            int totalExcerciseCount = excerciseObj.Count();
            int attemptedCount = 0;
            double completedPercentage = 0;
            for(var i=0; i< excerciseObj.Count;i++)
            {
                int excerciseId = excerciseObj[i].Id;
                var attempted = _db.TrackExcercises.Where(te => te.StudentId == studentId && te.ExcerciseId == excerciseId).Count();
            
                if(attempted >= 1)
                {
                    attemptedCount += 1;
                }
            
            }
            completedPercentage = ((double)attemptedCount/(double)totalExcerciseCount)*100;
            return completedPercentage;

        }
    }
}