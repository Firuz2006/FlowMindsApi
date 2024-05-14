using FlowMindsApi.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace FlowMindsApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class CategoryController(IMongoClient client) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Category category)
    {
        var db = client.GetDatabase("FlowMinds");
        var categories = db.GetCollection<Category>("Categories");
        await categories.InsertOneAsync(category);
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var db = client.GetDatabase("FlowMinds");
        var categories = db.GetCollection<Category>("Categories");
        var result = await categories.Find(_ => true).ToListAsync();
        return Ok(result);
    }
}