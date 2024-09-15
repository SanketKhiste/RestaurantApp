﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp_DAL.Models
{
    public class Customer
    {
        public int? CustomerID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? ContactNumber { get; set; }
        public string? Password { get; set; }
        //public string? CreatedAt { get; set; }
        //public ICollection<Order> Orders { get; set; }
    }
}
