using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AuthSystem2.Models
{
    public class Prescription
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Patient Name")] 
        public string PatientName { get; set; }

        [Required]
        [DisplayName("Patient Address")]
        public string PatientAddress { get; set; }

        [Required]
        [DisplayName("Medication")]
        public string Medication { get; set; }

        [Required]
        [DisplayName("Dosage")]
        public string Dosage { get; set; }

        [Required]
        [DisplayName("Prescription Date")]
        public DateTime PrescriptionDate { get; set; }

        [Required]
        [DisplayName("Doctor's Notes")]
        public string DocNotes { get; set; } 
    }
}
