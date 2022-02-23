﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Models.Customer
{
    public class RecipeDetail
    {
        public int Id { get; set; }
        public string Instructions { get; set; }
        public List<RecipeIngredientListItem> RecipeIngredients { get; set; }
    }
}
