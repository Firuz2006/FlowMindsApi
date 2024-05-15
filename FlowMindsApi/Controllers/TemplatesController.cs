using FlowMindsApi.Common.Interfaces;
using FlowMindsApi.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;

namespace FlowMindsApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class TemplatesController(ITemplateRepository repository) : ControllerBase
{
    private readonly ITemplateRepository _repository = repository;

    [EnableQuery]
    [HttpGet]
    public IQueryable<Template> Get()
    {
        return _repository.GetAll();
    }

    [EnableQuery]
    [HttpGet("GetById")]

    public IQueryable<Template> GetById([FromODataUri] string key)
    {
        return _repository.GetById(key);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Template Template)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _repository.Create(Template);

        return Created("Template", Template);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromODataUri] string key, [FromBody] Template Template)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (key != Template.Id)
        {
            return BadRequest();
        }

        await _repository.Update(Template);

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromODataUri] string key)
    {
        var Template = _repository.GetById(key);

        if (Template is null)
        {
            return BadRequest();
        }

        await _repository.Delete(Template.First());

        return NoContent();
    }
}