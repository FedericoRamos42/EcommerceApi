using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class OrderRepository : BaseRepository<Order>,IOrderRepository
    { 
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context ) : base( context ) 
        {
            _context = context;
        }

        public async Task<Order> GetByIdWithOrderDetails(int id)
        {
            var order = await _context.Orders
                                .Include(u=> u.User)
                                .Include(o => o.Details)
                                .ThenInclude(o=> o.Product)
                                .FirstOrDefaultAsync(o => o.Id == id);

            return order;                             
        }
        public async Task<IEnumerable<Order>> GetAllWithOrderDetails()
        {
            var orders = await _context.Orders.
                              Include(o => o.Details)
                             .ToListAsync();
            return orders;
        }
    }
}
