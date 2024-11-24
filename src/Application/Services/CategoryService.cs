using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task CreateCategory(string categoryName)
        {
           if(categoryName == null)
            {
                throw new NotFoundException("the category name is null");
            }
           Category category = new Category()
           {
               Name = categoryName,
           };
            await _categoryRepository.Create(category);
        }

        public async Task DeleteCategory(int id)
        {
           Category category = await _categoryRepository.GetById(id);
            if (category == null)
            {
                throw new NotFoundException($"the category with id {id} does not exist");
            }

           //aca falta implementar una baja logica.
            await _categoryRepository.Delete(category);
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            var list = await _categoryRepository.GetAll();
            return CategoryDto.CreateListDto(list);
        }
    }
}
