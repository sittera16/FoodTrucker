﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Models.Customer
{
    public class TransactionMenuItemCreate
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public int TransactionId { get; set; }
    }
}
