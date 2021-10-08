using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_App.Models
{
    public class TrackVideos
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime TotalDuration { get; set; }
        [Required]
        public DateTime CompletedDuration { get; set; }

        public Contents Content {get; set;}
        public Students Student {get;set;}        
        
        
    }
}