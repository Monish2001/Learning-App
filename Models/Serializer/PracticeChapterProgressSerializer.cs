using System.Collections.Generic;
public class ChaptersProgress{
    public int Id {get; set;}
    public string Name {get; set;}
    public int SubId {get; set;}
    public int TotalExcercise {get; set;}
    public int CompletionPercentage {get; set;}
}

public class ChapterProgressResponse{
    public List<ChaptersProgress> ChapterProgressResponseList = new List<ChaptersProgress>();
}