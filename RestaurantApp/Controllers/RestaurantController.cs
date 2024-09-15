using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp_BAL.Interface;
using RestaurantApp_DAL.Models;
using RestaurantApp_DAL.Models.Dtos;

namespace RestaurantApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurant _iRestaurant;

        public RestaurantController(IRestaurant restaurant) 
        {
            _iRestaurant = restaurant;
        }

        [HttpPost]
        [Route("RestaurantDetails")]
        public ResponseDTO RestaurantDetails(Restaurant restaurant)
        {
            ResponseDTO responseDTO = new ResponseDTO();
            try
            {
                _iRestaurant.RestaurantDetails(restaurant);
            }
            catch (Exception ex)
            {
                responseDTO.IsSuccess = false;
                ErrorDTO errorDTO = new ErrorDTO();
                errorDTO.ErrorCode = 500;
                errorDTO.ErrorMessage = "Something went wrong";
                responseDTO.ErrorDTOs.Add(errorDTO);
            }
            return responseDTO;
        }
    }
}
