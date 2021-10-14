using Microsoft.AspNetCore.Authorization;    
using Microsoft.AspNetCore.Mvc;    
using Microsoft.Extensions.Configuration;    
using Microsoft.IdentityModel.Tokens;    
using System;    
using System.IdentityModel.Tokens.Jwt;    
using System.Security.Claims;    
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learning_App.Models.Serializer;
using Learning_App.Data;
using Learning_App.Models;
using Learning_App.Utils;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


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
