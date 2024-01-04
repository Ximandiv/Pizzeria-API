using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Domain.Repositories.Base;
public interface IRepository <T> where T : class
{
    Task<T> CreateAsync (T entity);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<T> UpdateAsync (T entity);
    Task DeleteAsync (T entity);
}
