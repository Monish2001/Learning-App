using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_App.Models
{
    public class OTP
    {
        [Key]
        public int Id { get; set; }
        [Required]
        // public DateTime GeneratedTime { get; set; }
        public long Generatedtime {get; set;}
        [Required]
        public int Otp { get; set; }
        
        public int StudentId {get; set;}

        public Students Student{ get; set; }

    }
}