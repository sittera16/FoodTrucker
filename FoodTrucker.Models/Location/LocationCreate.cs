﻿using FoodTrucker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Models.Customer
{
    public class LocationCreate
    {
        [Required]
        public string Address { get; set; }
        [Required]
        public string Neighborhood { get; set; }
        [Required]
        [Display(Name ="Location Type")]
        public LocationType LocationType { get; set; }
    }
}
