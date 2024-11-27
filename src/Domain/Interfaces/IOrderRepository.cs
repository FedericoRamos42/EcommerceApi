using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetByIdWithOrderDetails(int id);
        Task<IEnumerable<Order>> GetAllWithOrderDetails();
    }
}
