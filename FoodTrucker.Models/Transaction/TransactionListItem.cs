﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Models.Customer
{
    public class TransactionListItem
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
