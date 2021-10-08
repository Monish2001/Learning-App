using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_App.Models
{
    public class Questions
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        public int MaxCredit { get; set; }
        [Required]
        public DateTime TimeLimit {get;set;}

        public Excercises Excercise {get; set;}
        public ICollection<Options> Option {get; set;}
    }
}