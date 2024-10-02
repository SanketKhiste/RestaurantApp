using Dapper;
using Microsoft.Data.SqlClient;
using RestaurantApp_DAL.Context;
using RestaurantApp_DAL.IRepository;
using RestaurantApp_DAL.Models.Dtos;
using RestaurantApp_DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp_DAL.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DapperContext _context;
        ConfigHelper _configuration = new ConfigHelper();

        public LoginRepository(DapperContext context) 
        {
            _context = context;
        }


        public ResponseDTO LoginDetails(Login login)
        {
            ResponseDTO responseDTO = new ResponseDTO();
            try
            {
                LoginResponse objResponse = new LoginResponse();
                using (IDbConnection con = new SqlConnection(_configuration.GetConnectionString("RestaurantConn")))
                {
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("Email", login.Email, direction: ParameterDirection.Input, dbType: DbType.String);
                    objResponse = con.Query<LoginResponse>("usp_GetUserLogin", param: dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault(); //await connection.QueryAsync<Company>(query);

                    if (objResponse != null)
                    {
                        responseDTO.IsSuccess = true;
                        responseDTO.ResponseObject = objResponse;
                    }
                    else
                    {
                        responseDTO.IsSuccess = false;
                        ErrorDTO errorDTO = new ErrorDTO();
                        errorDTO.ErrorCode = 100;
                        errorDTO.ErrorMessage = "Invalid User";
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
