using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagement.DataAccessLayer.Model
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        //[ForeignKey("PatientInfo")]
        public int PatientId { get; set; }
        //public PatientInfo PatientInfo { get; set; }
        public string Title { get; set; } 
        public string Description { get; set; } 
        public TimeSpan? StartTime { get; set; } 
        public TimeSpan? EndTime { get; set; } 
        public bool IsAllDay { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public string? DoctorId { get; set; }
        public string? UserCreatedId { get; set; }
    }

 
}
