using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizza.Domain.Repositories.Pizza;
using Pizza.Application.Commands.Pizza;
using Pizza.Application.Mappers.Pizza;
using Pizza.Application.Responses.Pizza;

namespace Pizza.Application.Handlers.CommandHandlers.Pizza
{
    public class CreatePizzaHandler : IRequestHandler<CreatePizzaCommand, PizzaResponse>
    {
        private readonly IPizzaRepository _pizzaRepository;
        public CreatePizzaHandler(IPizzaRepository repository)
        {
            _pizzaRepository = repository;
        }

        public async Task<PizzaResponse> Handle(CreatePizzaCommand request, CancellationToken cancellationToken)
        {
            var pizzaEntity = PizzaMapper.Mapper.Map<Domain.Entities.Pizza.Pizza>(request);

            if (pizzaEntity == null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            var newPizza = await _pizzaRepository.CreatePizzaAsync(pizzaEntity);
            var pizzaResponse = PizzaMapper.Mapper.Map<PizzaResponse>(newPizza);

            return pizzaResponse;
        }
    }
}
