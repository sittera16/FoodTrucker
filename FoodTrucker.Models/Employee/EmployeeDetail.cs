using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Models.Customer
{
    public class EmployeeDetail
    {
        public int Id { get; set; }
        [MaxLength(25)]
        public string FirstName { get; set; }
        [MaxLength(25)]
        public string LastName { get; set; }
        public DateTimeOffset HireDate { get; set; }
        public bool IsCurrentlyEmployeed { get; set; }
    }
}
