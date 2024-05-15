using FlowMindsApi.Common.Interfaces;
using FlowMindsApi.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;

namespace FlowMindsApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class StackHoldersController(IStackHolderRepository repository) : ControllerBase
{
    private readonly IStackHolderRepository _repository = repository;

    [EnableQuery]
    [HttpGet]
    public IQueryable<StackHolder> Get()
    {
        return _repository.GetAll();
    }

    [EnableQuery]
    [HttpGet]
    public IQueryable<StackHolder> GetById([FromODataUri] string key)
    {
        return _repository.GetById(key);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] StackHolder StackHolder)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _repository.Create(StackHolder);

        return Created("StackHolder", StackHolder);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromODataUri] string key, [FromBody] StackHolder StackHolder)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (key != StackHolder.Id)
        {
            return BadRequest();
        }

        await _repository.Update(StackHolder);

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromODataUri] string key)
    {
        var StackHolder = _repository.GetById(key);

        if (StackHolder is null)
        {
            return BadRequest();
        }

        await _repository.Delete(StackHolder.First());

        return NoContent();
    }
}