﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OnlineStore.Domain.Entities
{
    public class Product
    {
        
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Please enter a product name.")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter a description.")]
        public string Description { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Plese enter a positive price.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; }
    }
}
