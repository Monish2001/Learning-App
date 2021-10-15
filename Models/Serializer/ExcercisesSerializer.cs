using System.Collections.Generic;

public class Excercise{
    public int Id { get; set; }
    public int ChapterId {get; set;}
    public string Title { get; set; }
    public long Timelimit {get; set;}
    public int NoOfQuestions { get; set; }
    public int TotalCredit { get; set; }
    public int NoOfAttempts {get; set;}
    public int HighestScore {get; set;}
}

public class ExcerciseResponse
    {
        public List<Excercise> Excercises = new List<Excercise>();
    }

public class NoResponseFound
{
    public string Message {get; set;}
}
