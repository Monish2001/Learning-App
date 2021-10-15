using Learning_App.Models;

// // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 

public class StudentEnrollmentRequest
{
    public int StudentId { get; set; }
    public int BoardId { get; set; }
    // public int? ClassId { get; set; }
}

public class StudentEnrollment{
        public StudentEnrollmentRequest student_enrollment {get; set;}

        public StudentEnrollments createStudentEnrollmentObject()
        {
            StudentEnrollments s = new StudentEnrollments
            {
                BoardId = student_enrollment.BoardId,
                StudentId = student_enrollment.StudentId
            };
            return s;
        }
    }

