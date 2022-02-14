using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Data
{
    public enum LocationType
    {
        festival,
        sportingEvent,
        sideOfStreet,
        residentialArea,
        musicEvent,
        brewery
    }
    public class Location
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
