using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp_DAL.Models
{
    public class MenuItem
    {
        public int MenuItemID { get; set; }
        public int RestaurantID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
