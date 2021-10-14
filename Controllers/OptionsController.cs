using Microsoft.AspNetCore.Authorization;    
using Microsoft.AspNetCore.Mvc;    
using System.Collections.Generic;
using System.Linq;
using Learning_App.Data;
using Learning_App.Models;
using Newtonsoft.Json;

namespace Learning_App.Controllers    
{   
    public class OptionsController : Controller    
    {
        private readonly LearningAppDbContext _db;
    
        public OptionsController(LearningAppDbContext db)    
        {    
            _db = db;
        }
        
        public string OptionsList(int question_id)
        {            
            var optionsList = _db.Options.Where(o => o.QuestionId == question_id).ToList();

            if(optionsList.Count() == 0)
            {
                return null;
            }

            List<Option> ListOfOptions = new List<Option>();
            
            for (var i = 0; i < ListOfOptions.Count; i++)
            {
                Option responseObj = new Option(){
                    Id = optionsList[i].Id,
                    QuestionId = optionsList[i].QuestionId,
                    OptionValue = optionsList[i].OptionValue,
                };
                
                ListOfOptions.Add(responseObj);
            }

            // OptionResponse optionResponseObj = new OptionResponse(){
            //     Options = ListOfOptions
            // };

            string output = JsonConvert.SerializeObject(ListOfOptions);
            return output;
        }
    }
}