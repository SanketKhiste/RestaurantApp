using RestaurantApp_BAL.Interface;
using RestaurantApp_DAL.IRepository;
using RestaurantApp_DAL.Models;
using RestaurantApp_DAL.Models.Dtos;
using RestaurantApp_DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp_BAL.Services
{
    public class CustomerService : ICustomer
    {

        //private readonly CustomerRepository _customerRepository;
        //private readonly ICustomer _customer;
        private readonly ICustomerRepository _customer;

        public CustomerService(ICustomerRepository customer) 
        {
            _customer = customer;
        }

        public ResponseDTO CustomerDetail(Customer customer)
        {
            return _customer.CustomerDetail(customer);

        }

    }
}
