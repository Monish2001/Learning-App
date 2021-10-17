using System;
using Learning_App.Data;
using Learning_App.Models;
using System.Linq;
public class CheckCorrectOptionId{
    public int CorrectOptionId(int question_id, LearningAppDbContext _db)
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
}

