using Application.Dtos;
using Application.Dtos.Request;
using Application.Interfaces;
using Domain.Exceptions;
using Domain.Interfaces;
using MediaBrowser.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task CreateProduct(RequestCreateProduct request)
        {
            var category = await _categoryRepository.GetById(request.IdCategory);
            if (category == null) 
            {
                throw new NotFoundException($"The category with id {request.IdCategory} that not exist ");
            }

            var product = RequestCreateProduct.ToEntity(request,category);
            await _productRepository.Create(product);

        }

        public Task DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
           var list = await _productRepository.GetAll();
            return ProductDto.CreateList(list);
        }

        public async Task<ProductDto> GetById(int id)
        {
           var product = await  _productRepository.GetById(id);
            if(product == null)
            {
                throw new NotFoundException($"The product with id {id} that not exist ");
            }
            return ProductDto.CreateDto(product);
        }
    }
}
