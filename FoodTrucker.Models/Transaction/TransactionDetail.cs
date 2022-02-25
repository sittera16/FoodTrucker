using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Models.Customer
{
    public class TransactionDetail
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public int CustomerId { get; set; }
        public List<string> MenuItems { get; set; }
        public List<RecipeIngredientListItem> TransactionMenuItems { get; set; }
        public decimal TotalPrice { get; set; }
        public int LocationId { get; set; }
        public int EmployeeId { get; set; }
    }
}
