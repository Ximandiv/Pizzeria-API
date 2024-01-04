using Pizza.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Domain.Repositories.Pizza;

public interface IPizzaRepository : IRepository <Entities.Pizza.Pizza>
{
    Task<Entities.Pizza.Pizza> CreatePizzaAsync(Entities.Pizza.Pizza pizza);
    Task<IEnumerable<Entities.Pizza.Pizza>> GetAllPizzasAsync();
    Task<Entities.Pizza.Pizza> GetByIdPizzaAsync(int id);
    Task<string> UpdatePizzaAsync(Entities.Pizza.Pizza pizza);
    Task <string> DeletePizzaAsync(Entities.Pizza.Pizza pizza);
}
