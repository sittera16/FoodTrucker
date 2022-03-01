using FoodTrucker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Models.Customer
{
    public class TransactionMenuItemListItem
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public int TransactionId { get; set; }
        [Display(Name = "Menu Item Name")]
        public string MenuItemName { get; set; }
        [Display(Name = "Transaction Date")]
        public string TransactionDate { get; set; }
    }
}
