using System.Collections.Generic;
using System.Linq;
using Learning_App.Data;
using Newtonsoft.Json;
using System;

public class OptionList{
    public string OptionsList(int question_id, LearningAppDbContext _db)
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


