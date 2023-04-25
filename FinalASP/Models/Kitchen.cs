﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace FinalASP.Models
{
    public class Kitchen
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is Required")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        public string Locaion { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field is Required")]
        public string KitchenImages { get; set; } // need to be a list of images 
        [Required(ErrorMessage = "This field is Required")]
        public bool State { get; set; } // if the Kitchen reserved or not
        public string Domain { get; set; } = string.Empty;
        public double Phone { get; set; }
        [Required(ErrorMessage = "This field is Required")]
        public double Price { get; set; } // Kitchen rent price per hour
        public int PhysicalKitchenId { get; set; }
        public PhysicalKitchen PhysicalKitchen { get; set; }

    }
}