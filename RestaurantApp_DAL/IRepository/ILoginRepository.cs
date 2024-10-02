using RestaurantApp_DAL.Models.Dtos;
using RestaurantApp_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp_DAL.IRepository
{
    public interface ILoginRepository
    {
        ResponseDTO LoginDetails(Login login);
    }
}
