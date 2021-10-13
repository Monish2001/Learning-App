using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_App.Models
{
    public class Sessions
    {
        [Key]
        public int Id { get; set; }

        public string JwtToken {get; set;}
        
        // public DateTime CreatedTime {get; set;}
        public long Createdtime {get; set;}

        public bool Status {get; set;}

        public int StudentId {get;set;}

        public Students Student {get; set;}
        
    }
}