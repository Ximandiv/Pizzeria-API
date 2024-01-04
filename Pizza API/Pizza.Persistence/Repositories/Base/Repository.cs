using Microsoft.EntityFrameworkCore;
using Pizza.Infrastructure.Data;
using Pizza.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Persistence.Repositories.Base;

public class Repository <T> : IRepository<T> where T : class
{
    protected readonly PizzeriaContext _pizzeriaContext;
    public Repository(PizzeriaContext context)
    {
        _pizzeriaContext = context;
    }

    public async Task<T> CreateAsync(T entity)
    {
        await _pizzeriaContext.Set<T>().AddAsync(entity);
        await _pizzeriaContext.SaveChangesAsync();

        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        _pizzeriaContext.Set<T>().Remove(entity);
        await _pizzeriaContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _pizzeriaContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _pizzeriaContext.Set<T>().FindAsync(id);
    }

    public Task<T> UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
}
