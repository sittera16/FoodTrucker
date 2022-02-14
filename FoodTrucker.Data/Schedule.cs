using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Data
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTimeOffset Date { get; set; }
        public int LocationId { get; set; }
    }
}
