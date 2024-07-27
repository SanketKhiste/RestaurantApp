using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp_DAL.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int CustomerID { get; set; }
        public int RestaurantID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        public Customer Customer { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
