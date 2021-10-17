using Microsoft.AspNetCore.Authorization;    
using Microsoft.AspNetCore.Mvc;    
using System.Collections.Generic;
using System.Linq;
using Learning_App.Data;
using Newtonsoft.Json;

namespace Learning_App.Controllers    
{   
    public class QuestionsController : Controller    
    {
        private readonly LearningAppDbContext _db;
        // LearningAppDbContext db;
    
        public QuestionsController(LearningAppDbContext db)    
        {    
            _db = db;
        }
        

        [Authorize]
        [HttpGet]
        [Route("api/v1/chapters/{chapter_id}/excercises/{excercise_id}/questions")]
        public IActionResult ListOfQuestions([FromRoute] int chapter_id,[FromRoute] int excercise_id)
        {            
            var questionList = _db.Questions.Where(q => q.ExcerciseId == excercise_id).ToList();

            if(questionList.Count() == 0)
            {
                NoResponseFound noResponseFoundObj = new NoResponseFound{
                    Message = "Question not found for this particular excercise"
                };
                string noResponseFoundResponse = JsonConvert.SerializeObject(noResponseFoundObj);
                return Ok(noResponseFoundResponse);
            }

            List<Question> ListOfQuestion = new List<Question>();
            
            // OptionsController optionsObj = new OptionsController(db);
            
            for (var i = 0; i < questionList.Count; i++)
            {
                Question responseObj = new Question(){
                    Id = questionList[i].Id,
                    ExcerciseId = questionList[i].ExcerciseId,
                    QuestionStr = questionList[i].Question,
                    Timelimit = questionList[i].Timelimit,
                    MaxCredit = questionList[i].MaxCredit,
                    Options = OptionsList(questionList[i].Id)
                };
                
                ListOfQuestion.Add(responseObj);
            }

            QuestionResponse optionResponseObj = new QuestionResponse(){
                Questions = ListOfQuestion
            };

            string output = JsonConvert.SerializeObject(optionResponseObj);
            return Ok(output);
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