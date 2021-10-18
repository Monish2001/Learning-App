using Microsoft.AspNetCore.Authorization;    
using Microsoft.AspNetCore.Mvc;    
using System.Collections.Generic;
using System.Linq;
using Learning_App.Data;
using Learning_App.Models;
using Newtonsoft.Json;
using System;
using System.Security.Claims;
using Learning_App.Controllers;

namespace Learning_App.Controllers    
{   
    public class ExcercisesController : Controller    
    {
        private readonly LearningAppDbContext _db;
    
        public ExcercisesController(LearningAppDbContext db)    
        {    
            _db = db;
        }
        

        [Authorize]
        [HttpGet]
        [Route("api/v1/chapters/{chapter_id}/excercises")]
        public IActionResult ListOfExcercises([FromRoute] int chapter_id)
        {            
            var currentUser = HttpContext.User;
            
            var studentIdFromJWT = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            int studentId = Int32.Parse(studentIdFromJWT);

            var excerciseList = _db.Excercises.Where(e => e.ChapterId == chapter_id).ToList();

            if(excerciseList.Count() == 0)
            {
                NoResponseFound noResponseFoundObj = new NoResponseFound{
                    Message = "Excercise not found for this particular chapter"
                };
                string noResponseFoundResponse = JsonConvert.SerializeObject(noResponseFoundObj);
                return Ok(noResponseFoundResponse);
            }

            List<Excercise> ListOfExcercises = new List<Excercise>();
            
            for (var i = 0; i < excerciseList.Count; i++)
            {
                Excercise responseObj = new Excercise(){
                    Id = excerciseList[i].Id,
                    ChapterId = excerciseList[i].ChapterId,
                    Title = excerciseList[i].Title,
                    Timelimit = excerciseList[i].Timelimit,
                    NoOfQuestions = excerciseList[i].NoOfQuestions,
                    TotalCredit = excerciseList[i].MaxCredit,
                    NoOfAttempts = CalculateNoOfAttempts(excerciseList[i].Id, studentId),
                    HighestScore = CalculateHighestScore(excerciseList[i].Id, studentId)
                };
                
                ListOfExcercises.Add(responseObj);
            }

            ExcerciseResponse excerciseResponseObj = new ExcerciseResponse(){
                Excercises = ListOfExcercises
            };

            string output = JsonConvert.SerializeObject(excerciseResponseObj);
            return Ok(output);
        }

        public int CalculateNoOfAttempts(int excerciseId, int studentId)
        {
            var noOfAttemptsCount = _db.TrackExcercises.Where(te => te.ExcerciseId == excerciseId && te.StudentId == studentId).Count();
            return noOfAttemptsCount;
        }

        public int CalculateHighestScore(int excerciseId, int studentId)
        {
            
            var trackExcercisesObj = _db.TrackExcercises.Where(te => te.ExcerciseId == excerciseId && te.StudentId == studentId).ToList();

            int maxScoreTillNow = 0;

            for(var j = 0; j < trackExcercisesObj.Count; j++)
            {
                int correctAnsCount = 0;
                var trackQuesObj = _db.TrackQuestions.Where(tq => tq.TrackExcerciseId == trackExcercisesObj[j].Id && tq.StudentId == studentId).ToList();
                int maxCredit = 0;
                for (var i = 0; i < trackQuesObj.Count; i++)
                {
                    int quesId = trackQuesObj[i].QuestionId;
                    int? selectedOptionId = trackQuesObj[i].OptionId;
                    
                    CheckCorrectOptionId checkCorrectOptionIdObj = new CheckCorrectOptionId();
                    int? correctOptionId = checkCorrectOptionIdObj.CorrectOptionId(quesId,_db);
                    
                    var quesObj = _db.Questions.Where(q => q.Id == quesId).ToList();
                    maxCredit = quesObj[0].MaxCredit;

                    if(correctOptionId == selectedOptionId){
                        correctAnsCount +=1;
                    }

                }
                int totalScoreForCurrentEx = correctAnsCount * maxCredit; 
                if(maxScoreTillNow < totalScoreForCurrentEx)
                {
                    maxScoreTillNow = totalScoreForCurrentEx;
                }
            }
            return maxScoreTillNow;
        }
    }
}