using System.Collections.Generic;

public class ExcerciseQuestionReport{
    public int QuestionId { get; set; }
    public string QuestionStr { get; set; }
    public string Options {get; set;}
    public int? SelectedOptionId { get; set; }
    public int? CorrectOptionId {get; set;}
}

public class Analytics
    {
        public int Score {get; set;}
        public int AccuracyPercentage {get; set;}
        public long TotalDurationInMins {get; set;}
        public int AttemptNo {get; set;}
        public long AttemptedDate {get; set;}
        public int CorrectCount {get; set;}
        public int InCorrectCount {get; set;}
        public int UnAnsweredCount {get; set;}

    }

public class Report{
    public List<ExcerciseQuestionReport> QuestionReportList = new List<ExcerciseQuestionReport>();
    public Analytics ExcerciseAnalytics {get; set;}
}
