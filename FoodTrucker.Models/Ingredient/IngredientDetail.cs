using FoodTrucker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Models.Customer
{
    public class IngredientDetail
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        [Range(0, 150)]
        [Display(Name = "Quantity in Stock")]
        public int QuantityInStock { get; set; }
        [Display(Name = "Ingredient Type")]
        public IngredientType IngredientType { get; set; }
    }
}
