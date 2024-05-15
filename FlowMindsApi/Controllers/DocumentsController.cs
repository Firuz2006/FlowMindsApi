using FlowMindsApi.Common.Interfaces;
using FlowMindsApi.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;

namespace FlowMindsApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class DocumentsController(IDocumentRepository repository) : ControllerBase
{
    private readonly IDocumentRepository _repository = repository;

    [EnableQuery]
    [HttpGet]
    public IQueryable<Document> Get()
    {
        return _repository.GetAll();
    }

    [EnableQuery]
    [HttpGet("GetById")]

    public IQueryable<Document> GetById([FromODataUri] string key)
    {
        return _repository.GetById(key);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Document document)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _repository.Create(document);

        return Created("Document", document);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromODataUri] string key, [FromBody] Document document)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (key != document.Id)
        {
            return BadRequest();
        }

        await _repository.Update(document);

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromODataUri] string key)
    {
        var document = _repository.GetById(key);

        if (document is null)
        {
            return BadRequest();
        }

        await _repository.Delete(document.First());

        return NoContent();
    }
}
