using FlowMindsApi.Common.Interfaces;
using FlowMindsApi.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;

namespace FlowMindsApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class DepartmentsController(IDepartmentRepository repository) : ControllerBase
{
    private readonly IDepartmentRepository _repository = repository;

    [EnableQuery]
    [HttpGet]
    public IQueryable<Department> Get()
    {
        return _repository.GetAll();
    }

    [EnableQuery]
    [HttpGet]
    public IQueryable<Department> GetById([FromODataUri] string key)
    {
        return _repository.GetById(key);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Department department)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _repository.Create(department);

        return Created("department", department);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromODataUri] string key, [FromBody] Department department)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (key != department.Id)
        {
            return BadRequest();
        }

        await _repository.Update(department);

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromODataUri] string key)
    {
        var department = _repository.GetById(key);

        if (department is null)
        {
            return BadRequest();
        }

        await _repository.Delete(department.First());

        return NoContent();
    }
}
