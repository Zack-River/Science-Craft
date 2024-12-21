using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ScienceCraft.Web.Models
{
    public class Session
    {
        [Key]
        public int Id { get; set; }

        [Required,StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; } = DateTime.Now;


        public int KitId { get; set; } = 0;

        [ValidateNever]
        public Kit? Kit { get; set; }

        
        [Required]
        public int CourseId { get; set; }

        [ValidateNever]
        public Course Course { get; set; }

        
        [Required]
        public int InscId { get; set; }

        [ValidateNever]
        public Employee Empolyee { get; set; }

    }
}