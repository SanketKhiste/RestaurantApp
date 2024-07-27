using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp_BAL.Interface;
using RestaurantApp_BAL.Services;
using RestaurantApp_DAL.Models;
using RestaurantApp_DAL.Models.Dtos;

namespace RestaurantApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _iCustomer;
        //private readonly CustomerService _customerService;
        private readonly IConfiguration _appsetiing;
        public CustomerController(ICustomer customer, IConfiguration configuration) 
        {
            _iCustomer = customer;
            _appsetiing = configuration;
        }
        //public async Task<string>
        [HttpPost]
        [Route("CustomerDetail")]
        public ResponseDTO CustomerDetail(Customer customer)
        {
            ResponseDTO responseDTO = new ResponseDTO();
            try 
            {
                _iCustomer.CustomerDetail(customer);
            }
            catch (Exception ex)
            {
                responseDTO.IsSuccess = false;
            }
            return responseDTO;
        }
    }
}
