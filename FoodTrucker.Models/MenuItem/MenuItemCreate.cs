using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FoodTrucker.Models.Customer
{
    public class MenuItemCreate
    {
        [Required]
        [Display(Name ="Recipe Name")]
        public int RecipeId { get; set; }
        [Required]
        [Display(Name = "Menu Item Name")]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
