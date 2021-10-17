using System.Collections.Generic;

public class Content{
    public int Id { get; set; }
    public int ChapterId {get; set; }
    public string Title { get; set; }
    public string ContentLink{get; set;}
    public string ContentType {get; set;}
    public long? TotalDuration {get; set;}
    public long? CompletedDuration {get; set;}
    public int? PdfTotalPages {get; set;}
    public int? PdfReadPages {get; set;}
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
