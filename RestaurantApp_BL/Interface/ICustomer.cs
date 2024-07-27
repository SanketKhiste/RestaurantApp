using RestaurantApp_DAL.Models;
using RestaurantApp_DAL.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp_BAL.Interface
{
    public interface ICustomer
    {
        ResponseDTO CustomerDetail(Customer customer);
    }
}
