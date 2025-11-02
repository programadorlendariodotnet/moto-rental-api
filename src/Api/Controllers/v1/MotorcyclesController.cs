using Api.Controllers.Utils;
using Api.DTOs;
using Application.Features.Motorcycles.Commands.CreateMotorcycle;
using Application.Features.Motorcycles.Commands.DeleteMotorcycle;
using Application.Features.Motorcycles.Commands.UpdateMotorcycle;
using Application.Features.Motorcycles.Queries.GetMotorcycleByUId;
using Application.Features.Motorcycles.Queries.GetMotorcyclesByPlate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1;

[ApiController]
[Route("v1/motorcycles")]
public class MotorcyclesController(IMediator mediator) : CustomControllerBase
{
    [HttpGet("filter")]
    public async Task<IActionResult> GetMotorcycles([FromQuery] string? plate)
    {
        var result = await mediator.Send(new GetMotorcyclesByPlateQuery(plate));
        return CustomResult(result);
    }

    [HttpGet("{uId}")]
    public async Task<IActionResult> GetMotorcycleByUId([FromRoute] string uId)
    {
        var result = await mediator.Send(new GetMotorcycleByUIdQuery(uId));
        return CustomResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMotorcycle([FromBody] CreateMotorcycleCommand command)
    {
        var result = await mediator.Send(command);
        return CustomResult(result);
    }

    [HttpPut("{uId}")]
    public async Task<IActionResult> Update(
        [FromRoute] string uId, [FromBody] UpdateMotorcycleDto updateMotorcycleDto)
    {
        var result = await mediator.Send(new UpdateMotorcycleCommand(uId, updateMotorcycleDto.Plate));
        return CustomResult(result);
    }

    [HttpDelete("{uId}")]
    public async Task<IActionResult> DeleteMotorcycle([FromRoute] string uId)
    {
        var result = await mediator.Send(new DeleteMotorcycleCommand(uId));
        return CustomResult(result);
    }
}