using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Kursach
{
    public interface IRepository<T> where T : class
    {
        Task<T> Create(T entity);

        /// <summary>
        /// Get Entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> Get(int id);

        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetAll();

        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);

        List<T> Find(Expression<Func<T, bool>> predicate);

        Task<bool> Remove(int id);
    }
}
