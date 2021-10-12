using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_App.Models
{
    public class Classes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        // public int BoardId {get; set;}
        
        public Boards Board { get; set; }
        public ICollection<StudentEnrollments> StudentEnrollment {get; set;}
        public ICollection<Subjects> Subject {get; set;}
        public ICollection<Students> Student {get; set;}
    }
}