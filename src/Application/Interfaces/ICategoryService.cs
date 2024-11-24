using Application.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICategoryService
    {
        public Task CreateCategory(string categoryName);
        public Task<IEnumerable<CategoryDto>>GetCategories();
        public Task DeleteCategory(int id);

    }
}
