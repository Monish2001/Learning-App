using Learning_App.Models;

public class VoteResponse{
    public Vote VoteObj {get; set;}
    public string Message {get; set;}
}

public class Vote{
    public int StudentId {get; set;}
    public int ContentId {get; set;}
    public long VotedTime {get; set;}
    public bool? IsVoted {get; set;}
}

public class VoteRequest{
    public bool vote {get; set;}
}