using System.ComponentModel.DataAnnotations;
using System.Security;

namespace ScienceCraft.Entities.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = "No Description";
        public string? ImgUrl { get; set; }

    }
}
