using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_App.Models
{
    public class Options
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string OptionValue { get; set; }
        [Required]
        public bool IsCorrect { get; set; }

        public int QuestionId {get; set;}

        public Questions Question {get; set;}
        
        
    }
}