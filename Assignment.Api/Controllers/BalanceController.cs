using Assignment.Application.Authentication.Queries.Balance;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Api.Controllers;


[Route("api")]
[ApiController]
[Authorize]
public class BalanceController : ControllerBase
{
    private readonly ISender _mediator;
    public BalanceController(ISender mediator)
    {
        _mediator = mediator;
    }
    [HttpPost("balance")]
    public async Task<IActionResult> GetBalance([FromBody] BalanceQuery query)
    {
        var balance = await _mediator.Send(query);
        return Ok(new { balance });
    }
}