using Microsoft.AspNetCore.Authorization;    
using Microsoft.AspNetCore.Mvc;    
using System.Collections.Generic;
using System.Linq;
using Learning_App.Data;
using Learning_App.Models;
using Newtonsoft.Json;

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
                    NoOfAttempts = 2,
                    HighestScore = 20
                };
                
                ListOfExcercises.Add(responseObj);
            }

            ExcerciseResponse excerciseResponseObj = new ExcerciseResponse(){
                Excercises = ListOfExcercises
            };

            string output = JsonConvert.SerializeObject(excerciseResponseObj);
            return Ok(output);
        }
    }
}