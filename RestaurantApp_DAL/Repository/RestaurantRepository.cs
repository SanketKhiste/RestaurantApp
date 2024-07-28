using RestaurantApp_DAL.Context;
using RestaurantApp_DAL.IRepository;
using RestaurantApp_DAL.Models;
using RestaurantApp_DAL.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp_DAL.Repository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly DapperContext _dapperContext;

        ConfigHelper _configHelper = new ConfigHelper();

        public RestaurantRepository(DapperContext dapperContext, ConfigHelper configHelper)
        {
            _dapperContext = dapperContext;
            _configHelper = configHelper;
        }

        public ResponseDTO RestaurantDetails(Restaurant restaurant)
        {
            ResponseDTO responseDTO = new ResponseDTO();
            return responseDTO;
        }
    }
}
