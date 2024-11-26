using Application.Dtos;
using Application.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> GetById(int id);
        Task<IEnumerable<ProductDto>> GetAll();
        Task CreateProduct(RequestCreateProduct request);
        Task DeleteProduct(int id);
        Task UpdateStock(RequestUpdateProductStock request);

    }
}
