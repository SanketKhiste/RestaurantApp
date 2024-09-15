
using RestaurantApp_BAL.Interface;
using RestaurantApp_DAL.IRepository;
using RestaurantApp_DAL.Models;
using RestaurantApp_DAL.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp_BAL.Services
{
    public class RestaurantService : IRestaurant
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public ResponseDTO RestaurantDetails(Restaurant restaurant)
        {
            //_restaurantRepository.
            //ResponseDTO responseDTO = new ResponseDTO();
            return _restaurantRepository.RestaurantDetails(restaurant);
            //return responseDTO;
        }
    }
}
