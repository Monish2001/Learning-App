using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_App.Models
{
    public class TrackExcercises
    {
        [Key]
        public int Id { get; set; }
        [Required]
        // public DateTime StartTime { get; set; }
        public long Starttime {get; set;}
        [Required]
        // public DateTime EndTime { get; set; }
        public long Endtime {get; set;}

        public int ExcerciseId {get; set;}
        public int StudentId {get; set;}

        public Excercises Excercise {get; set;}
        public Students Student {get;set;}        
        
        
    }
}