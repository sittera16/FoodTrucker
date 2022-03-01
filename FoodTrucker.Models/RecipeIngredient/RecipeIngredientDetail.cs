using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Models.Customer
{
    public class RecipeIngredientDetail
    {
        public int Id { get; set; }
        public int IngredientId { get; set; }
        public int RecipeId { get; set; }
        [Display(Name = "Ingredient Name")]
        public string IngredientName { get; set; }
        [Display(Name = "Recipe Name")]
        public string RecipeName { get; set; }
    }
}
