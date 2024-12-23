﻿using Application.Dtos;
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
        Task CreateCategory(string categoryName);
        Task<IEnumerable<CategoryDto>>GetCategories();
        Task DeleteCategory(int id);

    }
}
