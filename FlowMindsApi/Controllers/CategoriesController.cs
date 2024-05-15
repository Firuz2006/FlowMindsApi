using FlowMindsApi.Common.Interfaces;
using FlowMindsApi.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;

using MongoDB.Driver;

namespace FlowMindsApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class CategoriesController(ICategoryRepository repository) : ControllerBase
{
    private readonly ICategoryRepository _repository = repository;

    [EnableQuery]
    [HttpGet]
    public IQueryable<Category> Get()
    {
        return _repository.GetAll();
    }

    [EnableQuery]
    [HttpGet]
    public IQueryable<Category> GetById([FromODataUri] string key)
    {
        return _repository.GetById(key);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Category category)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _repository.Create(category);

        return Created("Category", category);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromODataUri] string key, [FromBody] Category category)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (key != category.Id)
        {
            return BadRequest();
        }

        await _repository.Update(category);

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromODataUri] string key)
    {
        var category = _repository.GetById(key);

        if (category is null)
        {
            return BadRequest();
        }

        await _repository.Delete(category.First());

        return NoContent();
    }
}