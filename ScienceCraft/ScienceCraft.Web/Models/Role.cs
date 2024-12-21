using System.ComponentModel.DataAnnotations;

namespace ScienceCraft.Web.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        
        [Required,StringLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}