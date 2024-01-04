using MediatR;
using Pizza.Application.Mappers;
using Pizza.Application.Mappers.Pizza;
using Pizza.Application.Queries.Pizza;
using Pizza.Application.Responses.Pizza;
using Pizza.Domain.Repositories.Pizza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Application.Handlers.QueryHandlers.Pizza
{
    public class GetPizzaHandler : IRequestHandler<GetAllPizzaQuery, List<PizzaResponse>>
    {
        private readonly IPizzaRepository _pizzaRepository;
        public GetPizzaHandler(IPizzaRepository repository)
        {
            _pizzaRepository = repository;
        }

        public async Task<List<PizzaResponse>> Handle
            (GetAllPizzaQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.Entities.Pizza.Pizza> Pizzas = await _pizzaRepository.GetAllPizzasAsync();
            List<PizzaResponse> MappedPizzas = Pizzas
                                                .Select(pizza => PizzaMapper.Mapper.Map<PizzaResponse>(pizza))
                                                                                    .ToList();

            return MappedPizzas;
        }
    }
}
