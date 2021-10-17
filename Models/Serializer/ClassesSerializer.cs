using System.Collections.Generic;
public class Class
{
    public int Id { get; set; }
    public string Title { get; set; }
}

public class ClassResquest
{
    public int Id {get; set;}
}

public class ListClassesResponse{
    public List<Class> Classes = new List<Class>();
}

public class PostClassResponse{
    public Class Class {get; set;}
}