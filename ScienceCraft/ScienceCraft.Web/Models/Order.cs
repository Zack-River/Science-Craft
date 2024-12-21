using System.ComponentModel.DataAnnotations;

namespace ScienceCraft.Web.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required,MaxLength(50)]
        public string Fname { get; set; } = string.Empty;

        [Required,MaxLength(50)]
        public string Lname { get; set; } = string.Empty;

        [Required]
        public string EntityName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public string Request { get; set; } = "No Request";
    }
}
