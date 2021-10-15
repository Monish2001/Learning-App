using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_App.Models
{
    public class Subjects
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SubName { get; set; }
        
        public int ClassId {get; set;}

        public string logo {get;set;}
        

        public Classes Class {get; set;}
        public ICollection<Chapters> Chapter {get; set;}
    }
}