﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Models.Customer
{
    public class MenuItemEdit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RecipeId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
