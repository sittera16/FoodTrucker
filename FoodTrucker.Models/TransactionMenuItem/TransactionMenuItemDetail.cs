using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Models.Customer
{
    public class TransactionMenuItemDetail
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public int TransactionId { get; set; }
        public string MenuItemName { get; set; }
        public string TransactionDate { get; set; }
    }
}
