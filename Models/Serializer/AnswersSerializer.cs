public class AnswerResponse{
    public string Question {get; set;}
    public bool IsMarkedForReview {get; set;}
    public int? OptionId {get; set;}
    public string Option {get; set;}
}

public class AddAnswerRequest{
    public int OptionId {get; set;}
    public bool IsMarkedForReview {get; set;}
}

public class Response{
    public string Message {get; set;}
    public AnswerResponse AnswerObj {get; set;}
}