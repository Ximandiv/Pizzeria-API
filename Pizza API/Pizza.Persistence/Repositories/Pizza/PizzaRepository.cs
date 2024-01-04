using Microsoft.EntityFrameworkCore;
using Pizza.Domain.Repositories.Pizza;
using Pizza.Infrastructure.Data;
using Pizza.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Persistence.Repositories.Pizza;

public class PizzaRepository : Repository<Domain.Entities.Pizza.Pizza>, IPizzaRepository
{
    public PizzaRepository(PizzeriaContext context)
        : base(context) { }

    //Upon null return, means that a pizza exists, therefore will not create it.
    public async Task<Domain.Entities.Pizza.Pizza> CreatePizzaAsync(Domain.Entities.Pizza.Pizza pizza)
    {
        bool pizzaExists = await DoesPizzaExistByName(pizza.Pizza_Name);

        if(!pizzaExists)
        {
            try
            {
                pizza.Pizza_Name = pizza.Pizza_Name.ToLower();

                _pizzeriaContext.Pizzas.Add(pizza);

                _pizzeriaContext.SaveChanges();

                return pizza;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        return null;
    }

    public async Task<string> DeletePizzaAsync(Domain.Entities.Pizza.Pizza pizza)
    {
        string result = "";
        bool pizzaExists = await DoesPizzaExistById(pizza.Pizza_Id);

        if(pizzaExists)
        {
            try
            {
                _pizzeriaContext.Pizzas.Remove(pizza);

                _pizzeriaContext.SaveChanges();

                result = "deleted";

                return result;
            }
            catch (DbUpdateException)
            {
                return result;
            }
        }

        return result;
    }

    public async Task<IEnumerable<Domain.Entities.Pizza.Pizza>> GetAllPizzasAsync() => await _pizzeriaContext.Pizzas.ToListAsync();

    public async Task<Domain.Entities.Pizza.Pizza> GetByIdPizzaAsync(int id)
    {
        Domain.Entities.Pizza.Pizza? foundPizza = await _pizzeriaContext.Pizzas.Where(pizza => pizza.Pizza_Id == id).FirstOrDefaultAsync();

        if(foundPizza != null)
        {
            return foundPizza;
        }

        return foundPizza;
    }

    public async Task<string> UpdatePizzaAsync(Domain.Entities.Pizza.Pizza pizza)
    {
        string result = "";

        bool pizzaExists = await DoesPizzaExistById(pizza.Pizza_Id);

        if(pizzaExists)
        {
            try
            {
                _pizzeriaContext.Pizzas.Entry(pizza);
                await _pizzeriaContext.SaveChangesAsync();

                result = "success";

                return result;
            }
            catch (DbUpdateConcurrencyException)
            {
                return result;
            }
        }

        return result;
    }

    //Checks if the pizza exists or not.
    private async Task<bool> DoesPizzaExistById(int id)
    {
        Domain.Entities.Pizza.Pizza? foundPizza = await GetByIdPizzaAsync(id);

        if(foundPizza == null)
        {
            return false;
        }

        return true;
    }

    private async Task<bool> DoesPizzaExistByName(string pizzaName)
    {
        Domain.Entities.Pizza.Pizza? foundPizza = await _pizzeriaContext
                                                    .Pizzas
                                                        .Where(pizza => pizza.Pizza_Name == pizzaName)
                                                        .FirstOrDefaultAsync();

        if(foundPizza == null)
        {
            return false;
        }

        return true;
    }
}
