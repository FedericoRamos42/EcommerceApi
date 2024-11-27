using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Request
{
    public class RequestCreateOrder
    {
        public int UserId { get; set; }
        public List<ProductInOrderDto> Products { get; set; }

    }
}
