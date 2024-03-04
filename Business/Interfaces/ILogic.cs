using Entities.DTO.Request.Person;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ILogic<T, U> where T : class where U : class
    {
        Task<U> Add(T entity);
        Task<U> Update(int id, T entity);
        Task Delete(int id);
        Task<U> GetById(int id);
        Task<IEnumerable<T>> GetAll();
    }
}