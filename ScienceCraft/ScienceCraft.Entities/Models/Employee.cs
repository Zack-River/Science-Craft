using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ScienceCraft.Entities.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(120)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(20)]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public decimal Salary { get; set; } = decimal.Zero;

        [Required]
        public DateTime JoinTime { get; set; } = DateTime.Now;

        // Self-referencing foreign key
        public int? ManagerId { get; set; }

        [ValidateNever]
        public Employee? Manager { get; set; }

        [ValidateNever]
        public ICollection<Employee>? Subordinates { get; set; } = new List<Employee>();

        [Required]
        public int RoleId { get; set; }

        [ValidateNever]
        public Role Role { get; set; } = null!;
    }
}
