using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RestaurantApp_DAL.Context;
using RestaurantApp_DAL.IRepository;
using RestaurantApp_DAL.Models;
using RestaurantApp_DAL.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp_DAL.Repository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly DapperContext _dapperContext;

        ConfigHelper _configuration = new ConfigHelper();

        public RestaurantRepository(DapperContext dapperContext, ConfigHelper configHelper)
        {
            _dapperContext = dapperContext;
            _configuration = configHelper;
        }

        public ResponseDTO RestaurantDetails(Restaurant restaurant)
        {
            ResponseDTO responseDTO = new ResponseDTO();
            try
            {
                using (IDbConnection con = new SqlConnection(_configuration.GetConnectionString("RestaurantConn")))
                {
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("Name", restaurant.Name, direction: ParameterDirection.Input, dbType: DbType.String);
                    dynamicParameters.Add("Address", restaurant.Address, direction: ParameterDirection.Input, dbType: DbType.String);
                    dynamicParameters.Add("City", restaurant.City, direction: ParameterDirection.Input, dbType: DbType.String);
                    dynamicParameters.Add("State", restaurant.State, direction: ParameterDirection.Input, dbType: DbType.String);
                    dynamicParameters.Add("ZipCode", restaurant.ZipCode, direction: ParameterDirection.Input, dbType: DbType.String);
                    dynamicParameters.Add("PhoneNumber", restaurant.PhoneNumber, direction: ParameterDirection.Input, dbType: DbType.String);
                    dynamicParameters.Add("restaurantID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    //dynamicParameters.Add("Message", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                    con.Execute("Usp_Insert_restaurants", param: dynamicParameters, commandType: CommandType.StoredProcedure); //await connection.QueryAsync<Company>(query);
                    var restaurantID = dynamicParameters.Get<int?>("restaurantID");
                    if (restaurantID != null)
                    {
                        responseDTO.IsSuccess = true;
                        responseDTO.Message = "Hi you have succefully created restaurantID " + restaurantID;
                    }
                    else
                    {
                        responseDTO.IsSuccess = false;
                        ErrorDTO errorDTO = new ErrorDTO();
                        errorDTO.ErrorCode = 100;
                        errorDTO.ErrorMessage = "restaurant is not created";
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
