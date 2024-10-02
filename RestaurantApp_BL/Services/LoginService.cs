using RestaurantApp_BAL.Interface;
using RestaurantApp_DAL.IRepository;
using RestaurantApp_DAL.Models.Dtos;
using RestaurantApp_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp_BAL.Services
{
    public class LoginService : ILogin
    {
        private readonly ILoginRepository _login;

        public LoginService(ILoginRepository login)
        {
            _login = login;
        }

        public ResponseDTO LoginDetails(Login login)
        {
            return _login.LoginDetails(login);

        }
    }
}
