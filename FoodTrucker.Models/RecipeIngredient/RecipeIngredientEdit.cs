using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Models.Customer
{
    public class RecipeIngredientEdit
    {
        public int Id { get; set; }
        [Display(Name = "Ingredient Name")]
        public int IngredientId { get; set; }
        [Display(Name = "Recipe Name")]
        public int RecipeId { get; set; }
    }
}
