using Microsoft.AspNetCore.Authorization;    
using Microsoft.AspNetCore.Mvc;    
using System.Collections.Generic;
using System.Linq;
using Learning_App.Data;
using Learning_App.Models;
using Newtonsoft.Json;
using System.Security.Claims;
using System;
namespace Learning_App.Controllers    
{   
    public class ContentsController : Controller    
    {
        private readonly LearningAppDbContext _db;
    
        public ContentsController(LearningAppDbContext db)    
        {    
            _db = db;
        }
        

        [Authorize]
        [HttpGet]
        [Route("api/v1/chapters/{chapter_id}/contents/{pg_no}")]
        public IActionResult ListOfContents([FromRoute] int chapter_id, [FromRoute] int pg_no)
        {
            var currentUser = HttpContext.User;
            
            var StudentIdFromJWT = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            int studentId = Int32.Parse(StudentIdFromJWT);

            int skipper = 0;
            int limit = 5;
            if(pg_no!=1){
                skipper = (pg_no - 1) * limit;
            }
            
            var ContentList = _db.Contents.OrderBy(c => c.Id).Where(c => c.ChapterId == chapter_id).Skip(skipper).Take(limit).ToList();
            string output = CommonContentResponse(ContentList,studentId);
            return Ok(output);
        }

        [Authorize]
        [HttpGet]
        [Route("api/v1/chapters/{chapter_id}/contents")]
        public IActionResult ViewAllContents([FromRoute] int chapter_id)
        {    
            var currentUser = HttpContext.User;
            
            var studentIdFromJWT = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            int studentId = Int32.Parse(studentIdFromJWT);

            var ContentList = _db.Contents.Where(c => c.ChapterId == chapter_id).ToList();
            
            string output = CommonContentResponse(ContentList,studentId);

            return Ok(output);
        }

        public string CommonContentResponse(List<Contents> ContentList, int studentId)
        {
            int pdf_count = 0;
            int video_count = 0;

            List<Content> ListOfContents = new List<Content>();
            TrackPdfAndVideo trackPdfAndVideoObj = new TrackPdfAndVideo();
            for (var i = 0; i < ContentList.Count; i++)
            {
                int? totalPages = null;
                int? viewedPages = null;
                long? totalDuration = null;
                long? completedDuration = null;

                if(ContentList[i].ContentType == "Pdf"){
                    IDictionary<string,int?> trackPdfResponse = trackPdfAndVideoObj.TrackPDF(ContentList[i].Id, studentId,_db);
                    totalPages = trackPdfResponse["Total"];
                    viewedPages = trackPdfResponse["Viewed"];
                }
                else{
                    IDictionary<string,long?> trackVideoResponse = trackPdfAndVideoObj.TrackVideo(ContentList[i].Id, studentId,_db);
                    totalDuration = trackVideoResponse["Total"];
                    completedDuration = trackVideoResponse["Completed"];
                }
                
                Content responseObj = new Content(){
                    Id = ContentList[i].Id,
                    ChapterId = ContentList[i].ChapterId,
                    Title = ContentList[i].Title,
                    ContentLink = ContentList[i].ContentData,
                    ContentType = ContentList[i].ContentType,
                    TotalDuration = totalDuration,
                    CompletedDuration = completedDuration,
                    PdfTotalPages = totalPages,
                    PdfReadPages = viewedPages 
                };
                if(ContentList[i].ContentType.Equals("Pdf"))
                {
                    pdf_count+=1;
                }
                else{
                    video_count+=1;
                }

                ListOfContents.Add(responseObj);
            }

            ContentCount countObj = new ContentCount(){
                PdfCount = pdf_count,
                VideoCount = video_count
            };

            ContentResponse contentResponseObj = new ContentResponse(){
                Contents = ListOfContents,
                Contents_Count = countObj
            };

            string output = JsonConvert.SerializeObject(contentResponseObj);
            return output;
        }
    }
}