using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Data
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string EmailAddress { get; set; }
        public DateTimeOffset BirthDate { get; set; }
    }
}
