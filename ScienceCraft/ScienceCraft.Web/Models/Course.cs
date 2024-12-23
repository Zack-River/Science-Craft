using System.ComponentModel.DataAnnotations;

namespace ScienceCraft.Web.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; } = "No Description";

        [Required]
        public string? Image {  get; set; }

        [Required]
        public bool Approval { get; set; } = false;

        public string Status { get; set; } = "Pending";


        ICollection<Session> sessions { get; set; }
    }
}
