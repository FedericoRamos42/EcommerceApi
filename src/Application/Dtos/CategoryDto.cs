using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products = new List<Product>();
        public static CategoryDto CreateDto(Category category)
        {
            CategoryDto dto = new ()
            {
                Id = category.Id,
                Name = category.Name,
            };
            return dto;
        }
        public static IEnumerable<CategoryDto> CreateListDto(IEnumerable<Category> categories) 
        {
            List<CategoryDto> categoryDtos = new List<CategoryDto>();
            foreach (var item in categories)
            {
                categoryDtos.Add(CreateDto(item));
            }
            return categoryDtos;
        }
    }


}
