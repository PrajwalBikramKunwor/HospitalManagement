using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.BusinessLayer.DTOs
{
    public class PatientInfoDTO
    {
        public int PatientId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string? Gender { get; set; }

        public string? Address { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }
        public string? MedicalRecords { get; set; }
        public string? UserCreatedId { get; set; }

        public IEnumerable<PatientInfoDTO>? PatientDTO { get; set; }

        public int? PatientRetrieveId { get; set; }
    }
}
