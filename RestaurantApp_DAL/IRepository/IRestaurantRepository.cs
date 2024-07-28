using RestaurantApp_DAL.Models;
using RestaurantApp_DAL.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp_DAL.IRepository
{
    public interface IRestaurantRepository
    {
        ResponseDTO RestaurantDetails(Restaurant restaurant);
    }
}
