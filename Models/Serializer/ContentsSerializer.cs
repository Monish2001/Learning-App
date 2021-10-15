using System.Collections.Generic;

public class Content{
    public int Id { get; set; }
    public int ChapterId {get; set; }
    public string Title { get; set; }
    public string ContentLink{get; set;}
    public string ContentType {get; set;}
    public int? TotalDuration {get; set;}
    public int? CompletedDuration {get; set;}
    public bool? IsPdfViewed {get; set;}

}

public class ContentCount
    {
        public int PdfCount {get; set;}
        public int VideoCount {get; set;}
    }

public class ContentResponse
    {
        public List<Content> Contents = new List<Content>();
        public ContentCount Contents_Count;
    }
