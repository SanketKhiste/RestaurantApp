using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp_DAL.Models
{
    public class LoginResponse
    {
        public string CustomerId { get; set;}
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public string Email { get; set;}
        public string Rolename { get; set;}
        public string? Token { get; set; }
    }
}
