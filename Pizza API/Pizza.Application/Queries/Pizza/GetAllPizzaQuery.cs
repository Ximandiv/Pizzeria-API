using MediatR;
using Pizza.Application.Responses;
using Pizza.Application.Responses.Pizza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Application.Queries.Pizza
{
    public class GetAllPizzaQuery : IRequest<List<PizzaResponse>>
    {
    }
}
