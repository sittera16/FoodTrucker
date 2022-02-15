using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Models.Customer
{
    public class ScheduleEdit
    {
        [Required]
        public DateTimeOffset Date { get; set; }
        [Required]
        public int LocationId { get; set; }
    }
}
