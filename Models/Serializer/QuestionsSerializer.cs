using System.Collections.Generic;

public class Question{
    public int Id { get; set; }
    public int ExcerciseId {get; set;}
    public string QuestionStr { get; set; }
    public int MaxCredit { get; set; }
    public long Timelimit {get; set;}

    public string Options {get; set;}
}

public class QuestionResponse
    {
        public List<Question> Questions = new List<Question>();
    }
