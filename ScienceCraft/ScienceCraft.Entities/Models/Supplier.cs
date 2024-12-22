﻿using System.ComponentModel.DataAnnotations;

namespace ScienceCraft.Entities.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        //not complete
    }
}