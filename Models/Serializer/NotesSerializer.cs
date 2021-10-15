// using Learning_App.Models;

public class NoteResponse{
    public Note NoteObj {get; set;}
    public string Message {get; set;}
}

public class Note{
    public int StudentId {get; set;}
    public int ContentId {get; set;}
    public long NotesCreatedTime {get; set;}
    public string Notes {get; set;}
}

public class NoteRequest{
    public string note {get; set;}
}