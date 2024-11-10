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
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
                JWTTokenResponse objToken = new JWTTokenResponse();
                using (IDbConnection con = new SqlConnection(_configuration.GetConnectionString("RestaurantConn")))
                {
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("Email", login.Username, direction: ParameterDirection.Input, dbType: DbType.String);
                    dynamicParameters.Add("Password", login.Password, direction: ParameterDirection.Input, dbType: DbType.String);
                    objResponse = con.Query<LoginResponse>("usp_GetUserLogin", param: dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault(); //await connection.QueryAsync<Company>(query);

                    if (objResponse != null)
                    {
                        if(objResponse.Email == login.Username)
                        {
                            // Create user claims
                            var claims = new List<Claim>
                            {
                                //new Claim(ClaimTypes.Name, objResponse.FirstName),
                                new Claim("Id", objResponse.CustomerId.ToString()),
                                new Claim("FirstName", objResponse.FirstName),
                                new Claim("Email", objResponse.Email),
                                new Claim("Role", objResponse.Rolename)
                                // Add additional claims as needed (e.g., roles, etc.)
                            };
                            //var userRoles = objResponse.UserRoles.Where(u => u.UserId == user.Id).ToList();
                            //var roleIds = userRoles.Select(s => s.RoleId).ToList();
                            //var roles = _context.Roles.Where(r => roleIds.Contains(r.Id)).ToList();
                            //foreach (var role in roles)
                            //{
                                claims.Add(new Claim(ClaimTypes.Role, objResponse.Rolename));
                            //}
                            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetString("JWT:Key")));
                            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                            var tokeOptions = new JwtSecurityToken(
                                issuer: _configuration.GetString("JWT:Issuer"), 
                                audience: _configuration.GetString("JWT:Audience"), 
                                claims: claims, 
                                expires: DateTime.Now.AddHours(3),
                                //expires: DateTime.Now.AddMinutes(_configuration.GetInt32("TokenValidityInMinutes")),
                                signingCredentials: signinCredentials
                                );
                            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                            objResponse.Token = tokenString;
                            responseDTO.IsSuccess = true;
                            responseDTO.ResponseObject = objResponse;
                        }
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

        // Generating token based on user information
        private JwtSecurityToken GenerateAccessToken(string userName)
        {
            // Create user claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName),
                // Add additional claims as needed (e.g., roles, etc.)
            };

            // Create a JWT
            var token = new JwtSecurityToken(
                issuer: _configuration.GetString("JWT:Issuer"),
                audience: _configuration.GetString("JWT:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(1), // Token expiration time
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetString("Jwt:Key"))),
                    SecurityAlgorithms.HmacSha256)
            );

            return token;
        }
    }
}
