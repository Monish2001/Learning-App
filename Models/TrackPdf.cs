using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_App.Models
{
    public class TrackPdf
    {
        [Key]
        public int Id { get; set; }
        
        // public bool IsViewed { get; set; }

        public int TotalPages {get; set;}
        public int ViewedPages {get; set;}

        public int ContentId {get; set;}
        public int StudentId {get; set;}
        
        public Contents Content {get; set;}
        public Students Student {get;set;}
        
    }
}