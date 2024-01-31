using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AuthSystem2.Models
{
    public class PatientMedHx
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Patient Name")]
        public string PatientName { get; set; }

        [Required]
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [DisplayName("Gender")]
        public string Gender { get; set; }

        [Required]
        [DisplayName("Visit Date")]
        public DateTime VisitDate { get; set; }

        [Required]
        [DisplayName("Chief Complaint")]
        public string ChiefComplaint { get; set; }

        [Required]
        [DisplayName("Diagnosis")]
        public string Diagnosis { get; set; }

        [Required]
        [DisplayName("Treatment")]
        public string Treatment { get; set; }

        [Required]
        [DisplayName("DoctorsNotes")]
        public string DocNotes { get; set; } 
    }
}
