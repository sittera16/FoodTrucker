using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Models.Customer
{
    public class TransactionDetail
    {
        public int Id { get; set; }
        [Display(Name = "Customer Name")]
        public int CustomerId { get; set; }
        [Display(Name = "Transaction Date")]
        public DateTime TransactionDate { get; set; }
        [Display(Name = "Menu Items Sold")]
        public List<string> MenuItems { get; set; }
        public List<RecipeIngredientListItem> TransactionMenuItems { get; set; }
        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }
        [Display(Name = "Location Address")]
        public int LocationId { get; set; }
        [Display(Name = "Employee Name")]
        public int EmployeeId { get; set; }
    }
}
