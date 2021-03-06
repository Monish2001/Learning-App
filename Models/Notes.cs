using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_App.Models
{
    public class Notes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Note { get; set; }
        [Required]
        // public DateTime CreatedTime {get; set;}
        public long Createdtime {get;set;}

        public int ContentId {get; set;}
        public int StudentId {get;set;}

        public Contents Content {get; set;}
        public Students Student {get;set;}
        
    }
}