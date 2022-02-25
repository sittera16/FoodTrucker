﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Data
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int MenuItemId { get; set; }
        public decimal TotalPrice { get; set; }
        public int LocationId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual List<MenuItem> MenuItems { get; set; }
        public virtual Location Location { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
