using FoodTrucker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Models.Customer
{
    public class LocationDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Neighborhood { get; set; }
        [Required]
        public LocationType LocationType { get; set; }
    }
}
