using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_App.Models
{
    public class Chapters
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        // public string logo {get; set; }

        public int SubjectId {get; set;}

        public Subjects Subject {get; set;}
        public ICollection<Contents> Content {get; set;}
        public ICollection<Excercises> Excercise {get; set;}
               
    }
}