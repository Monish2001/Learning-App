using Microsoft.AspNetCore.Authorization;    
using Microsoft.AspNetCore.Mvc;    
using System.Collections.Generic;
using System.Linq;
using Learning_App.Data;
using Newtonsoft.Json;
using System;
using System.Security.Claims;
using Learning_App.Models;

namespace Learning_App.Controllers    
{   
    public class AnswersController : Controller    
    {
        private readonly LearningAppDbContext _db;
    
        public AnswersController(LearningAppDbContext db)    
        {    
            _db = db;
        }
        

        [Authorize]
        [HttpPost]
        [Route("api/v1/questions/{question_id}/answer/attempt/{attempt_id}")]
        public IActionResult AddAnswer([FromRoute] int question_id,[FromRoute] int attempt_id,[FromForm] AddAnswerRequest reqObj)
        {            
            var currentUser = HttpContext.User;
            
            var StudentIdFromJWT = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            int StudentId = Int32.Parse(StudentIdFromJWT);

            // bool MarksObtained = CheckAnswer(question_id,reqObj.OptionId);
            
            TrackQuestions inputObj = new TrackQuestions(){
                MarkedForReview = reqObj.IsMarkedForReview,
                // Attempted = true,
                // MarksObtained = reqObj.OptionId,
                StudentId = StudentId,
                TrackExcerciseId = attempt_id,
                OptionId = reqObj.OptionId,
                QuestionId = question_id
            };
                
            _db.TrackQuestions.Add(inputObj);
            _db.SaveChanges(); 
            
            string output = AnswerControllerResponse("Added Successfully", question_id, StudentId, attempt_id);
            return Ok(output);
            
        }

        [Authorize]
        [HttpPut]
        [Route("api/v1/questions/{question_id}/answer/attempt/{attempt_id}")]
        public IActionResult UpdateAnswer([FromRoute] int question_id,[FromRoute] int attempt_id,[FromForm] AddAnswerRequest reqObj)
        {            
            var currentUser = HttpContext.User;
            
            var StudentIdFromJWT = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            int StudentId = Int32.Parse(StudentIdFromJWT);

            var trackQuestionObj = _db.TrackQuestions.Where(tq => tq.StudentId == StudentId && tq.QuestionId == question_id && tq.TrackExcerciseId == attempt_id).ToList();
            trackQuestionObj.ForEach(tq => tq.OptionId = reqObj.OptionId);
            trackQuestionObj.ForEach(tq => tq.MarkedForReview = reqObj.IsMarkedForReview);
            _db.SaveChanges();

    
            string output = AnswerControllerResponse("Updated Successfully", question_id, StudentId, attempt_id);
            return Ok(output);
        }

        // public bool CheckAnswer(int question_id, int option_id)
        // {
        //     var checkAnswer = _db.Options.Where(o => o.Id == option_id && o.QuestionId == question_id).ToList();
        //     if(checkAnswer[0].IsCorrect==true)
        //     {
        //         return true;
        //     }
        //     else{
        //         return false;
        //     }
        // }

        public string AnswerControllerResponse(string message, int question_id, int StudentId, int attempt_id)
        {
            var trackQuesObj = _db.TrackQuestions.Where(tq => tq.StudentId == StudentId && tq.QuestionId == question_id && tq.TrackExcerciseId == attempt_id).ToList();
            bool isMarkedForReview = trackQuesObj[0].MarkedForReview;
            int? optionId = trackQuesObj[0].OptionId;

            var questionObj = _db.Questions.Where(q => q.Id == question_id).ToList();
            string question = questionObj[0].Question;

            var optionObj = _db.Options.Where(o => o.Id == optionId).ToList();
            string option = optionObj[0].OptionValue;

            AnswerResponse answerResponseObj = new AnswerResponse{
                Question = question,
                Option = option,
                OptionId = optionId,
                IsMarkedForReview = isMarkedForReview
            };

            Response responseObj = new Response{
                Message = message,
                AnswerObj = answerResponseObj
            };

            string output = JsonConvert.SerializeObject(responseObj);
            return output;
        }

    }
}