using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_App.Models
{
    public class Excercises
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        // public DateTime TimeLimit { get; set; }
        public long Timelimit {get; set;}
        [Required]
        public int NoOfQuestions { get; set; }
        [Required]
        public int MaxCredit { get; set; }
        public int ChapterId {get; set;}

        public Chapters Chapter {get; set;}
        public ICollection<Questions> Question {get;set;}
    }
}