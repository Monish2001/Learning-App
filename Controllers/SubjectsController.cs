using Microsoft.AspNetCore.Authorization;    
using Microsoft.AspNetCore.Mvc; 
using System;        
using System.Security.Claims;    
using System.Collections.Generic;
using System.Linq;
using Learning_App.Data;
using Newtonsoft.Json;

namespace Learning_App.Controllers    
{   
    public class SubjectsController : Controller    
    {
        private readonly LearningAppDbContext _db;
    
        public SubjectsController(LearningAppDbContext db)    
        {    
            _db = db;
        }
        

        [Authorize]
        [HttpGet]
        [Route("api/v1/classes/{class_id}/subjects")]
        public IActionResult ListOfSubjects([FromRoute] int class_id)
        {
            // To get the student id from jwt token
            var currentUser = HttpContext.User;
            
            var StudentIdFromJWT = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            int studentId = Int32.Parse(StudentIdFromJWT);
            
            var SubList = _db.Subjects.Where(s => s.ClassId == class_id).ToList();
            
            List<Subject> ListOfSubjects = new List<Subject>();
            
            for (var i = 0; i < SubList.Count; i++)
            {
                Subject responseObj = new Subject(){
                    Id = SubList[i].Id,
                    ClassId = SubList[i].ClassId,
                    Name = SubList[i].SubName,
                    Logo = SubList[i].logo,
                    Percentage = CalculateSubjectCompletedPercentage(SubList[i].Id,studentId)
                };

                ListOfSubjects.Add(responseObj);
            }
            ListSubjectsResponse subjectResponseObj = new ListSubjectsResponse(){
                Subjects = ListOfSubjects
            };
            string output = JsonConvert.SerializeObject(subjectResponseObj);
            return Ok(output);
        }

        public double? CalculateSubjectCompletedPercentage(int subjectId, int studentId)
        {
            var chapterList = _db.Chapters.Where(c => c.SubjectId == subjectId).ToList();
            double? totalCompletionPercentage = 0;
            double? pdfCompletionPercentage = 0;
            double? videoCompletionPercentage = 0;
            int? totalPdfPages = 0;
            int? totalReadPages = 0;
            long? totalDuration = 0;
            long? completedDuration = 0;
            for(var i=0; i < chapterList.Count; i++)
            {

                var contentList = _db.Contents.Where(c => c.ChapterId == chapterList[i].Id).ToList();
                for(var j=0; j<contentList.Count; j++){
                    if(contentList[j].ContentType == "Pdf"){
                        IDictionary<string,int?> trackPdfResponse = TrackPDF(contentList[j].Id, studentId);
                        totalPdfPages += trackPdfResponse["Total"];
                        totalReadPages += trackPdfResponse["Viewed"];
                    }
                    else{
                        IDictionary<string,long?> trackVideoResponse = TrackVideo(contentList[j].Id, studentId);
                        totalDuration += trackVideoResponse["Total"];
                        completedDuration += trackVideoResponse["Completed"];
                    }
                }
            }
            
            pdfCompletionPercentage = ((double)totalReadPages/(double)totalPdfPages)*100;
            videoCompletionPercentage = ((double)completedDuration/(double)totalDuration)*100;
            totalCompletionPercentage = (pdfCompletionPercentage+videoCompletionPercentage)/2;
            return totalCompletionPercentage;
        }

        public IDictionary<string,int?> TrackPDF (int contentId, int studentId)
        {
            IDictionary<string, int?> trackPdfPages = new Dictionary<string, int?>();
            var trackPdfObj = _db.TrackPdf.Where(tp => tp.ContentId == contentId && tp.StudentId == studentId).ToList();
            int? totalPages = 0;
            int? viewedPages = 0;
            if(trackPdfObj.Count()!=0){
                totalPages = trackPdfObj[0].TotalPages;
                viewedPages = trackPdfObj[0].ViewedPages;
                trackPdfPages.Add("Total",totalPages);
                trackPdfPages.Add("Viewed", viewedPages);
            }
            else{
                trackPdfPages.Add("Total",totalPages);
                trackPdfPages.Add("Viewed", viewedPages);
            }
            return trackPdfPages;
        }

        public IDictionary<string,long?> TrackVideo (int contentId, int studentId)
        {
            IDictionary<string, long?> trackVideos = new Dictionary<string, long?>();
            var trackVideoObj = _db.TrackVideos.Where(tv => tv.ContentId == contentId && tv.StudentId == studentId).ToList();
            long? totalDurationInMins = 0;
            long? completedDurationInMins = 0;
            
            if(trackVideoObj.Count()!=0){
                totalDurationInMins = trackVideoObj[0].Totalduration;
                completedDurationInMins = trackVideoObj[0].Completeduration;
                trackVideos.Add("Total",totalDurationInMins);
                trackVideos.Add("Completed", completedDurationInMins);
            }
            else{
                trackVideos.Add("Total",totalDurationInMins);
                trackVideos.Add("Completed", completedDurationInMins);
            }
            
            return trackVideos;
        }
    }
}