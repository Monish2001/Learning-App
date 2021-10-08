using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_App.Models
{
    public class Contents
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ContentData { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ContentType { get; set; }
        
        
        public Chapters Chapter {get; set;}
        public ICollection<Notes> Note {get; set;}
        public ICollection<TrackPdf> TrackPdf {get; set;}
    }
}