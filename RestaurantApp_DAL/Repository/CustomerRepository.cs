using Dapper;
using Microsoft.Data.SqlClient;
using RestaurantApp_DAL.Context;
using RestaurantApp_DAL.IRepository;
using RestaurantApp_DAL.Models;
using RestaurantApp_DAL.Models.Dtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace RestaurantApp_DAL.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DapperContext _context;
        ConfigHelper _configuration = new ConfigHelper();
        //private readonly ConfigHelper _configHelper;

        public CustomerRepository(DapperContext context)
        {
            _context = context;
            //_configHelper = configHelper;
        }
        public ResponseDTO CustomerDetail(Customer customer)
        {
            ResponseDTO responseDTO = new ResponseDTO();
            try
            {
                using (IDbConnection con = new SqlConnection(_configuration.GetConnectionString("RestaurantConn")))
                {
                    var dynamicParameters = new DynamicParameters();
                    //dynamicParameters.Add("CustomerID", customer.CustomerID, direction: ParameterDirection.InputOutput, dbType: DbType.Int32);
                    dynamicParameters.Add("FirstName", customer.FirstName, direction: ParameterDirection.Input, dbType: DbType.String);
                    dynamicParameters.Add("LastName", customer.LastName, direction: ParameterDirection.Input, dbType: DbType.String);
                    dynamicParameters.Add("Email", customer.Email, direction: ParameterDirection.Input, dbType: DbType.String);
                    dynamicParameters.Add("PhoneNumber", customer.PhoneNumber, direction: ParameterDirection.Input, dbType: DbType.String);
                    //dynamicParameters.Add("CreatedAt", customer.CreatedAt, direction: ParameterDirection.Input, dbType: DbType.String);
                    dynamicParameters.Add("CustomerID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    dynamicParameters.Add("Message", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                    //await db.ExecuteAsync("sp_AddCustomer", parameters, commandType: CommandType.StoredProcedure);

                    //return parameters.Get<int>("CustomerID");
                    //using (var connection = _context.CreateConnection())
                    //using (IDbConnection con = new SqlConnection(_configuration.GetConnectionString("UFOCUS")))
                    //{
                    //var companies = con.Execute("Usp_Insert_Customers", param: dynamicParameters, commandType: CommandType.StoredProcedure); //await connection.QueryAsync<Company>(query);
                    con.Execute("Usp_Insert_Customers", param: dynamicParameters, commandType: CommandType.StoredProcedure); //await connection.QueryAsync<Company>(query);
                    //var message = dynamicParameters.Get<string>("Message");
                    var CustomerID = dynamicParameters.Get<int?>("CustomerID");
                    //return companies.ToList();
                    if (CustomerID != null)
                    {
                        responseDTO.IsSuccess = true;
                        responseDTO.Message = "Hi you have succefully created customerID "+CustomerID;
                    }
                    else
                    {
                        responseDTO.IsSuccess = false;
                        ErrorDTO errorDTO = new ErrorDTO();
                        errorDTO.ErrorCode = 100;
                        errorDTO.ErrorMessage = "Customer is not created";
                        responseDTO.ErrorDTOs.Add(errorDTO);
                    }
                }
            }
            catch (Exception ex)
            {
                responseDTO.IsSuccess = false;
                ErrorDTO errorDTO = new ErrorDTO();
                errorDTO.ErrorCode = 500;
                errorDTO.ErrorMessage = "Something went wrong";
                responseDTO.ErrorDTOs.Add(errorDTO);
                //NLogManager.Error("Autologin.GetUserDetails() - Exception - " + ex.Message);
            }
            return responseDTO;
        }
    }
}
