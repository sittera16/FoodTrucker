using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Models.Customer
{
    public class CustomerCreate
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(25)]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        [MaxLength(100)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Display(Name = "Birth Date")]
        public DateTimeOffset BirthDate { get; set; }
    }
}
