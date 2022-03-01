using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Models.Customer
{
    public class TransactionMenuItemCreate
    {
        public int Id { get; set; }
        [Display(Name = "Menu Item Name")]
        public int MenuItemId { get; set; }
        [Display(Name = "Transaction Date")]
        public int TransactionId { get; set; }
    }
}
