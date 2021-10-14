using Microsoft.AspNetCore.Authorization;    
using Microsoft.AspNetCore.Mvc;    
using System.Collections.Generic;
using System.Linq;
using Learning_App.Data;
using Learning_App.Models;
using Newtonsoft.Json;

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
            int skipper = 0;
            int limit = 5;
            if(pg_no!=1){
                skipper = (pg_no - 1) * limit;
            }
            
            var ContentList = _db.Contents.OrderBy(c => c.Id).Where(c => c.ChapterId == chapter_id).Skip(skipper).Take(limit).ToList();
            string output = CommonContentResponse(ContentList);
            return Ok(output);
        }

        [Authorize]
        [HttpGet]
        [Route("api/v1/chapters/{chapter_id}/contents")]
        public IActionResult ViewAllContents([FromRoute] int chapter_id)
        {    
            var ContentList = _db.Contents.Where(c => c.ChapterId == chapter_id).ToList();
            
            string output = CommonContentResponse(ContentList);

            return Ok(output);
        }

        public string CommonContentResponse(List<Contents> ContentList)
        {
            int pdf_count = 0;
            int video_count = 0;

            List<Content> ListOfContents = new List<Content>();
            
            for (var i = 0; i < ContentList.Count; i++)
            {
                Content responseObj = new Content(){
                    Id = ContentList[i].Id,
                    ChapterId = ContentList[i].ChapterId,
                    Title = ContentList[i].Title,
                    ContentLink = ContentList[i].ContentData,
                    ContentType = ContentList[i].ContentType,
                    TotalDuration = 50,
                    CompletedDuration = 20,
                    IsPdfViewed = true,
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