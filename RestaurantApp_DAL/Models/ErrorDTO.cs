using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp_DAL.Models
{
    public class ErrorDTO
    {
        public int ErrorCode { get; set; } = 0;

        public string ErrorMessage { get; set; } = string.Empty;
    }
}
