using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Models.Customer
{
    public class ScheduleDetail
    {
        public int Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public int LocationId { get; set; }
    }
}
