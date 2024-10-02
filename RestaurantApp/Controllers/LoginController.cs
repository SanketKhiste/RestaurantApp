using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp_BAL.Interface;
using RestaurantApp_DAL.Models.Dtos;
using RestaurantApp_DAL.Models;

namespace RestaurantApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _iLogin;
        public LoginController(ILogin login) 
        {
            _iLogin = login;
        }

        [HttpPost]
        [Route("LoginDetails")]
        public ResponseDTO LoginDetails(Login login)
        {
            ResponseDTO responseDTO = new ResponseDTO();
            try
            {
                responseDTO = _iLogin.LoginDetails(login);
            }
            catch (Exception ex)
            {
                responseDTO.Message = ex.Message;
                responseDTO.IsSuccess = false;
            }
            return responseDTO;
        }
    }
}
