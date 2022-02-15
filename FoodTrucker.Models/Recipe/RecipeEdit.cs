using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Models.Customer
{
    public class RecipeEdit
    {
        [Required]
        public string Instructions { get; set; }
        [Required]
        public int RecipeIngredientId { get; set; }
    }
}
