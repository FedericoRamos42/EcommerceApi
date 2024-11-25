using Domain.Entities;
using Domain.Enums;
using MediaBrowser.Model.Dlna;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; } = string.Empty;
        public CategoryDto Category { get; set; } = new CategoryDto();
        public string Status { get; set; } = string.Empty;
        //public List<OrderDetail> OrderDetailsList { get; set; } = new List<OrderDetail>();

        public static ProductDto CreateDto (Product product)
        {
            ProductDto dto = new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Stock = product.Stock,
                Price = product.Price,
                Image = product.Image,
                Category = CategoryDto.CreateDto(product.Category),
                Status = product.Status.ToString(),
            };
            return dto;
        }

        public static IEnumerable<ProductDto> CreateList(IEnumerable<Product> products)
        {
            List<ProductDto> list = new List<ProductDto>();
            foreach (var item in products)
            {
                list.Add(CreateDto(item));
            }
            return list;
        }

    
    }
}
