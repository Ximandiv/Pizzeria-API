using AutoMapper;
using Pizza.Application.Commands.Pizza;
using Pizza.Application.Responses.Pizza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Application.Mappers.Pizza
{
    public class PizzaMappingProfile : Profile
    {
        public PizzaMappingProfile()
        {
            CreateMap<Domain.Entities.Pizza.Pizza, PizzaResponse>().ReverseMap();
            CreateMap<Domain.Entities.Pizza.Pizza, CreatePizzaCommand>().ReverseMap();
        }
    }
}
