using Learning_App.Models;

public class Vote{
    public Votes VoteObj {get; set;}
    public string Message {get; set;}
}

public class VoteRequest{
    public bool vote {get; set;}
}