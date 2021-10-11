using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_App.Models
{
    public class Students
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string MobileNo { get; set; }
        [Required]
        public string FullName{ get; set; }
        [Required]
        public DateTime DOB { get; set; }

        public StudentEnrollments StudentEnrollment {get; set;}
        public OTP Otp {get; set;}
        public Classes Class {get; set;}
        public ICollection<Sessions> Session {get; set;}
    
    }
}