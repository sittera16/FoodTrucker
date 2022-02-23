using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Models.Customer
{
    public class RecipeListItem
    {
        public int Id { get; set; }
        public List<string> Ingredients { get; set; }
    }
}
