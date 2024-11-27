using Application.Dtos;
using Application.Dtos.Request;

namespace Application.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> GetOrderWithDetails (int id);
        Task<IEnumerable<OrderDto>> GetAllOrders();
        Task CreateOrder (RequestCreateOrder orderDto);
        Task CanceledOrder (int id);
        
    }
}
