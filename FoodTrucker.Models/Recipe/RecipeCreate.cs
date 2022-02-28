using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Models.Customer
{
    public class RecipeCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Instructions { get; set; }
        public int RecipeIngredientId { get; set; }
    }
}
