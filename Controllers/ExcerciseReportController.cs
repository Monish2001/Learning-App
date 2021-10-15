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
    public class ExcerciseReportController : Controller    
    {
        private readonly LearningAppDbContext _db;
    
        public ExcerciseReportController(LearningAppDbContext db)    
        {    
            _db = db;
        }
        
        [Authorize]
        [HttpGet]
        [Route("api/v1/excercises/{excercise_id}/attempts/{attempt_id}/analytics")]
        public IActionResult ExcerciseAnalytics([FromRoute] int excercise_id,[FromRoute] int attempt_id)
        {            
            var currentUser = HttpContext.User;
            
            var studentIdFromJWT = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            int studentId = Int32.Parse(studentIdFromJWT);
            
            var trackQuesObj = _db.TrackQuestions.Where(tq => tq.TrackExcerciseId == attempt_id && tq.StudentId == studentId).ToList();
            
            int correctAnsCount = 0;
            int inCorrectAnsCount = 0;


            List<ExcerciseQuestionReport> listOfQuestionsReport = new List<ExcerciseQuestionReport>();
            
            for (var i = 0; i < trackQuesObj.Count; i++)
            {
                int quesId = trackQuesObj[i].QuestionId;
                int? selectedOptionId = trackQuesObj[i].OptionId;

                int? correctOptionId = CorrectOptionId(quesId);
                string options = OptionsList(quesId);

                var quesObj = _db.Questions.Where(q => q.Id == quesId).ToList();
                string question = quesObj[0].Question;

                ExcerciseQuestionReport questionReportObj = new ExcerciseQuestionReport(){
                    QuestionId = quesId,
                    QuestionStr = question,
                    Options = options,
                    SelectedOptionId = selectedOptionId,
                    CorrectOptionId = correctOptionId
                };
                listOfQuestionsReport.Add(questionReportObj);

                if(correctOptionId == selectedOptionId){
                    correctAnsCount +=1;
                }
                else{
                    inCorrectAnsCount +=1;
                }
            }

            var excerciseObj = _db.Excercises.Where(e => e.Id == excercise_id).ToList();
            var trackExcerciseObj = _db.TrackExcercises.Where(te => te.Id == attempt_id && te.StudentId == studentId).ToList();

            long excerciseStartTime = trackExcerciseObj[0].Starttime;
            long excerciseEndTime = trackExcerciseObj[0].Endtime;

            int maxCreditForAQues = excerciseObj[0].MaxCredit;
            long timeLimit = excerciseObj[0].Timelimit;


            int totalQuestion = _db.Questions.Where(q => q.ExcerciseId == excercise_id).Count();

            int attemptedQuestionsCount = trackQuesObj.Count();
            

            int score = correctAnsCount*maxCreditForAQues;
            int accuracyPercentage = (score/totalQuestion*maxCreditForAQues)*100;
            var totalDurationInMins = (excerciseEndTime- excerciseStartTime)/1000;
            int attemptNo = attempt_id;
            long attemptedDate = excerciseStartTime;
            int unAnsweredCount = totalQuestion - attemptedQuestionsCount;

            Analytics analyticsObj = new Analytics{
                Score = score,
                AccuracyPercentage = accuracyPercentage,
                TotalDurationInMins = totalDurationInMins,
                AttemptNo = attemptNo,
                AttemptedDate = attemptedDate,
                CorrectCount = correctAnsCount,
                InCorrectCount = inCorrectAnsCount,
                UnAnsweredCount = unAnsweredCount
            };

            Report responseReportObj = new Report{
                QuestionReportList = listOfQuestionsReport,
                ExcerciseAnalytics = analyticsObj
            };

            string output = JsonConvert.SerializeObject(responseReportObj);
            return Ok(output);
        }

        public int CorrectOptionId(int question_id)
        {
            var optionsList = _db.Options.Where(o => o.QuestionId == question_id).ToList();

            for (var i = 0; i < optionsList.Count; i++)
            {
                if(optionsList[i].IsCorrect == true)
                {
                    return optionsList[i].Id;
                }
            }
            return 0;
        }

        public string OptionsList(int question_id)
        {            
            var optionsList = _db.Options.Where(o => o.QuestionId == question_id).ToList();
            if(optionsList.Count() == 0)
            {
                return null;
            }

            List<Option> ListOfOptions = new List<Option>();
            
            for (var i = 0; i < optionsList.Count; i++)
            {
                Option responseObj = new Option(){
                    Id = optionsList[i].Id,
                    QuestionId = optionsList[i].QuestionId,
                    OptionValue = optionsList[i].OptionValue,
                };
                
                ListOfOptions.Add(responseObj);
            }
            string output = JsonConvert.SerializeObject(ListOfOptions);
            return output;
        }
    }
}