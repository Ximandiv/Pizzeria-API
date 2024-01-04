using MediatR;
using Pizza.Application.Responses.Pizza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Application.Commands.Pizza
{
    public class CreatePizzaCommand : IRequest<PizzaResponse>
    {
        public string Pizza_Name { get; set; }
        public string Pizza_Ingredients { get; set; }
        public int Pizza_Price { get; set; }
    }
}
