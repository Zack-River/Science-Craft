using System.ComponentModel.DataAnnotations;

namespace ScienceCraft.Entities.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public bool Status { get; set; }

        ICollection<Session> sessions { get; set; }
    }
}
