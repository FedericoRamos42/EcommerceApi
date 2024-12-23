﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<T>
    {
        public Task<T> GetById(int id);
        public Task<IEnumerable<T>> GetAll();
        public Task Create(T entity);
        public Task Update(T entity);
        public Task Delete(T entity);
        public Task<IEnumerable<T>> Search(Expression<Func<T, bool>> predicate);
    }
}
