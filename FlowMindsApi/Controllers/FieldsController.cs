using FlowMindsApi.Common.Interfaces;
using FlowMindsApi.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;

namespace FlowMindsApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class FieldsController(IFieldRepository repository) : ControllerBase
{
    private readonly IFieldRepository _repository = repository;

    [EnableQuery]
    [HttpGet]
    public IQueryable<Field> Get()
    {
        return _repository.GetAll();
    }

    [EnableQuery]
    [HttpGet]
    public IQueryable<Field> GetById([FromODataUri] string key)
    {
        return _repository.GetById(key);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Field Field)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _repository.Create(Field);

        return Created("Field", Field);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromODataUri] string key, [FromBody] Field Field)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (key != Field.Id)
        {
            return BadRequest();
        }

        await _repository.Update(Field);

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromODataUri] string key)
    {
        var Field = _repository.GetById(key);

        if (Field is null)
        {
            return BadRequest();
        }

        await _repository.Delete(Field.First());

        return NoContent();
    }
}