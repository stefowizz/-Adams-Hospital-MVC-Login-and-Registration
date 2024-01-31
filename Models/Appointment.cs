using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AuthSystem2.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Title")]
        public string? Title { get; set; }

        [Required]
        [DisplayName("Start Time")]
        public DateTime StartTime { get; set; }


        [Required]
        [DisplayName("End Time")]
        public DateTime EndTime { get; set; }

        [Required]
        [DisplayName("Location")]
        public string? Location { get; set; }

        [Required]
        [DisplayName("Description")]
        public string? Description { get; set; }
    }
}
