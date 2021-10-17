using System.Collections.Generic;

public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ClassId{get; set;}
    public int? Percentage { get; set; }
    public string Logo { get; set; }
}

public class ListSubjectsResponse{
    public List<Subject> Subjects = new List<Subject>();
}