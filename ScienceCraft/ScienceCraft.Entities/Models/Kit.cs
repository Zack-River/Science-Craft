using System.ComponentModel.DataAnnotations;

namespace ScienceCraft.Entities.Models
{
    public class Kit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string ImgUrl { get; set; } = string.Empty;

        ICollection<Supply>? Materials { get; set; }
    }
}
