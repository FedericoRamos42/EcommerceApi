using Application.Dtos;
using Application.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> GetOrderWithDetails (int id);
        Task<IEnumerable<OrderDto>> GetAllOrders();
        Task CreateOrder (RequestCreateUser orderDto);
        Task DeleteOrder (int id);

        
    }
}
