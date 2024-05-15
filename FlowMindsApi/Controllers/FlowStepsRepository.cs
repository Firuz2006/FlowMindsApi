using FlowMindsApi.Common.Interfaces;
using FlowMindsApi.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;

namespace FlowMindsApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class FlowStepsController(IFlowStepRepository repository) : ControllerBase
{
    private readonly IFlowStepRepository _repository = repository;

    [EnableQuery]
    [HttpGet]
    public IQueryable<FlowStep> Get()
    {
        return _repository.GetAll();
    }

    [EnableQuery]
    [HttpGet]
    public IQueryable<FlowStep> GetById([FromODataUri] string key)
    {
        return _repository.GetById(key);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] FlowStep FlowStep)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _repository.Create(FlowStep);

        return Created("FlowStep", FlowStep);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromODataUri] string key, [FromBody] FlowStep FlowStep)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (key != FlowStep.Id)
        {
            return BadRequest();
        }

        await _repository.Update(FlowStep);

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromODataUri] string key)
    {
        var FlowStep = _repository.GetById(key);

        if (FlowStep is null)
        {
            return BadRequest();
        }

        await _repository.Delete(FlowStep.First());

        return NoContent();
    }
}