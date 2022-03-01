using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Models.Customer
{
    public class TransactionCreate
    {
        [Display(Name = "Customer Name")]
        public int CustomerId { get; set; }
        public int TransactionMenuItemId { get; set; }
        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }
        [Display(Name = "Location Address")]
        public int LocationId { get; set; }
        [Display(Name = "Employee Name")]
        public int EmployeeId { get; set; }
    }
}
