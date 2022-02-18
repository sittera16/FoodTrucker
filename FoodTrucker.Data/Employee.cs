using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Data
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }
        public DateTimeOffset HireDate { get; set; }
        public bool IsCurrentlyEmployeed { get; set; }
    }
}
