using System.Collections.Generic;
public class Chapter
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int SubjectId{get; set;}
}

public class ListChaptersResponse{
    public List<Chapter> Chapters = new List<Chapter>();
}