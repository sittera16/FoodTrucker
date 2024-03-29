﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Data
{
    public enum IngredientType
    {
        Bread,
        Protein,
        Topping,
        Condiment,
        Seasoning,
        Side
    }
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        [Range(0,150)]
        public int QuantityInStock { get; set; }
        [Required]
        public IngredientType IngredientType { get; set; }
    }
}
