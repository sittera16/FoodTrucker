using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Models.Customer
{
    public class TransactionListItem
    {
        public int Id { get; set; }
        [Display(Name = "Transaction Date")]
        public DateTime TransactionDate { get; set; }
        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }
    }
}
