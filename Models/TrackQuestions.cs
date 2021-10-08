using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_App.Models
{
    public class TrackQuestions
    {
        [Key]
        public int Id { get; set; }
        
        public bool MarkedForReview { get; set; }
        
        public bool Attempted { get; set; }
        public int MarksObtained {get; set;}

        public Questions Question {get; set;}
        public Students Student {get; set;}
        public TrackExcercises TrackExcercise {get;set;}        
        public Options Option {get;set;}     
        
    }
}