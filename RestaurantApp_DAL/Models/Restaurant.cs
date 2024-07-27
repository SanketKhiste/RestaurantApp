using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp_DAL.Models
{
    public class Restaurant
    {
        public int RestaurantID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        //public ICollection<MenuItem> MenuItems { get; set; }
        //public ICollection<Review> Reviews { get; set; }
    }
}
