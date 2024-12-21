using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ScienceCraft.Web.Models
{
    public class Supply
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImgUrl { get; set; }

        [Required]
        public decimal Price { get; set; } = decimal.Zero;

        [Required]
        public int Quantity { get; set; } = 0;

        [Required]
        public int SupplierId { get; set; } = 0;

        [ValidateNever]
        public Supplier Supplier { get; set; }
    }
}
