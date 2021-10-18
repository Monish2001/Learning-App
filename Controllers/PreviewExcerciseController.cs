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
    public class PreviewExcerciseController : Controller    
    {
        private readonly LearningAppDbContext _db;
    
        public PreviewExcerciseController(LearningAppDbContext db)    
        {    
            _db = db;
        }
        
        [Authorize]
        [HttpGet]
        [Route("api/v1/excercises/{excercise_id}/attempts/{attempt_id}")]
        public IActionResult ExcercisePreview([FromRoute] int excercise_id,[FromRoute] int attempt_id)
        {            
            var currentUser = HttpContext.User;
            
            var studentIdFromJWT = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            int studentId = Int32.Parse(studentIdFromJWT);
            
            var trackQuesObj = _db.TrackQuestions.Where(tq => tq.TrackExcerciseId == attempt_id && tq.StudentId == studentId).ToList();
            int markedForReviewCount = 0;

            List<QuestionReport> listOfQuestionsReport = new List<QuestionReport>();
            OptionList optionObj = new OptionList();
            for (var i = 0; i < trackQuesObj.Count; i++)
            {
                int quesId = trackQuesObj[i].QuestionId;
                int? selectedOptionId = trackQuesObj[i].OptionId;
                bool isMarkedForReview = trackQuesObj[i].MarkedForReview;
                string options = optionObj.OptionsList(quesId,_db);

                var quesObj = _db.Questions.Where(q => q.Id == quesId).ToList();
                string question = quesObj[0].Question;

                QuestionReport questionReportObj = new QuestionReport(){
                    QuestionId = quesId,
                    QuestionStr = question,
                    IsMarkedForReview = isMarkedForReview,
                    Options = options,
                    SelectedOptionId = selectedOptionId
                };

                if(isMarkedForReview == true){
                    markedForReviewCount += 1;
                }

                listOfQuestionsReport.Add(questionReportObj);
            }

            var excerciseObj = _db.Excercises.Where(e => e.Id == excercise_id).ToList();
            int chapterId = excerciseObj[0].ChapterId;

            var chapterObj = _db.Chapters.Where(c => c.Id == chapterId).ToList();
            string chapterName = chapterObj[0].Name;

            int totalQuestion = _db.Questions.Where(q => q.ExcerciseId == excercise_id).Count();

            int attemptedQuestionsCount = trackQuesObj.Count();
            int unAnsweredCount = totalQuestion - attemptedQuestionsCount;

            PreviewReport previewReportObj = new PreviewReport{
                ChapterId = chapterId,
                ChapterName = chapterName,
                AttemptedQuestions = attemptedQuestionsCount,
                UnAnswered = unAnsweredCount,
                MarkedForReview = markedForReviewCount
            };

            Preview previewObj = new Preview{
                QuestionReportList = listOfQuestionsReport,
                TotalReportPreview = previewReportObj
            };
            string output = JsonConvert.SerializeObject(previewObj);
            return Ok(output);
        }
    }
}