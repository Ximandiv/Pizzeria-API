using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza.Application.Commands.Pizza;
using Pizza.Application.Queries.Pizza;
using Pizza.Application.Responses.Pizza;

namespace Pizza_API_Project.Controllers.Pizza;

[Route("[controller]")]
[ApiController]
public class PizzaController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly string _uri;

    //Replace the - with the localhost:(port) that shows after you deploy the project.
    public PizzaController(IMediator mediator)
    {
        _mediator = mediator;
        _uri = "https://-/Pizza";
    }

    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<List<PizzaResponse>> GetAllPizzas()
    {
        return await _mediator.Send(new GetAllPizzaQuery());
    }

    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<PizzaResponse>> CreatePizza([FromBody] CreatePizzaCommand command)
    {
        var result = await _mediator.Send(command);

        if (result != null)
        {
            return Created(_uri, result);
        }

        return BadRequest(result);
    }
}
