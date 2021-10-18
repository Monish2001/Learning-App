using System.Collections.Generic;
using System.Linq;
using Learning_App.Data;
using Learning_App.Models;
using System;

public class TrackPdfAndVideo{
    public IDictionary<string,int?> TrackPDF (int contentId, int studentId, LearningAppDbContext _db)
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

        public IDictionary<string,long?> TrackVideo (int contentId, int studentId, LearningAppDbContext _db)
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