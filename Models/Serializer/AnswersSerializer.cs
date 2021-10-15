public class AnswerResponse{
    public int Id {get; set;}
    public bool IsMarkedForReview {get; set;}
    public bool Attempted {get; set;}
    public int MarksObtained {get; set;}
    public int QuestionId {get; set;}
    public int StudentId {get; set;}
    public int TrackExcerciseId {get; set;}
    public int OptionId {get; set;}
}

public class AddAnswerRequest{
    public int OptionId {get; set;}
    public bool IsMarkedForReview {get; set;}
}

public class ResponseObj{
    public string Message {get; set;}
    
}