using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_App.Models
{
    public class Votes
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        // public DateTime CreatedTime {get;set;}
        public long Createdtime {get; set;}

        public bool IsVoted { get; set; }

        public int StudentId {get; set;}
        public int ContentId {get; set;}
        
        public Contents Content {get; set;}
        public Students Student {get;set;}
        
    }
}