using FlowMindsApi.Common.Interfaces;
using FlowMindsApi.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;

namespace FlowMindsApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class RolesController(IRoleRepository repository) : ControllerBase
{
    private readonly IRoleRepository _repository = repository;

    [EnableQuery]
    [HttpGet]
    public IQueryable<Role> Get()
    {
        return _repository.GetAll();
    }

    [EnableQuery]
    [HttpGet("GetById")]

    public IQueryable<Role> GetById([FromODataUri] string key)
    {
        return _repository.GetById(key);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Role Role)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _repository.Create(Role);

        return Created("Role", Role);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromODataUri] string key, [FromBody] Role Role)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (key != Role.Id)
        {
            return BadRequest();
        }

        await _repository.Update(Role);

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromODataUri] string key)
    {
        var Role = _repository.GetById(key);

        if (Role is null)
        {
            return BadRequest();
        }

        await _repository.Delete(Role.First());

        return NoContent();
    }
}