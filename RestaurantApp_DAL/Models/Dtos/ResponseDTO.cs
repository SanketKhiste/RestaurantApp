using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp_DAL.Models.Dtos
{
    public class ResponseDTO
    {
        public bool IsSuccess { get; set; }

        public object ResponseObject { get; set; }

        public string Message { get; set; }

        public List<ErrorDTO> ErrorDTOs { get; set; } = new();
    }
}
