using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_App.Models
{
    public class StudentEnrollments
    {
        [Key]
        public int Id { get; set; }
        
        // public Students Student { get; set; }
        public Boards Board { get; set; }
        public Classes Class { get; set; }
    }
}