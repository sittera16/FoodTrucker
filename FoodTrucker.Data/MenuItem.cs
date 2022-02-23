using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Data
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        public int RecipeId { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
