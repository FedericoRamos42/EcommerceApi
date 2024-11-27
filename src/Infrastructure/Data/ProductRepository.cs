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
    public class ProductRepository : BaseRepository<Product> , IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllWithCategory()
        {
            var list = await _context.Products.Include(p => p.Category).ToListAsync();
            return list;
        }

        public async Task<Product> GetByIdWithCategory(int id )
        {
            var product = await _context.Products.Include(p => p.Category)
                                                  .FirstOrDefaultAsync(p=> p.Id == id);
            return product;
        }
    }
}
