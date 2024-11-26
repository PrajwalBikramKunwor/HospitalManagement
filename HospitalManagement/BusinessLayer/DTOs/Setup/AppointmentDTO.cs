using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.BusinessLayer.DTOs.Setup
{
    public class AppointmentDTO
    {
        [Key]
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public bool IsAllDay { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string? Status { get; set; }
        public string? DoctorId { get; set; }
        public string? UserCreatedId { get; set; }
        public IEnumerable<AppointmentDTO>? AppointmentDTOs { get; set; }
    }

    // Enum to represent different statuses of the appointment
    //public enum AppointmentStatus
    //{
    //    Scheduled,
    //    Completed,
    //    Canceled
    //}
}
