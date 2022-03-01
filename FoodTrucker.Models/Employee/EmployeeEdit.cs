using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Models.Customer
{
    public class EmployeeEdit
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(25)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Hire Date")]
        public DateTimeOffset HireDate { get; set; }
        [Required]
        [Display(Name = "Currently Employeed")]
        public bool IsCurrentlyEmployeed { get; set; }
    }
}
