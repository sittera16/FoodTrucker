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
        public int CustomerId { get; set; }
        public int MenuId { get; set; }
        public decimal TotalPrice { get; set; }
        public int LocationId { get; set; }
        public int EmployeeId { get; set; }
    }
}
