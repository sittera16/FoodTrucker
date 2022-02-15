using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Data
{
    public enum IngredientType
    {
        bread,
        protein,
        topping,
        condiment,
        seasoning,
        side
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
        public double QuantityInStock { get; set; }
        [Required]
        public IngredientType IngredientType { get; set; }
    }
}
