using Microsoft.AspNetCore.Mvc;

using MongoDB.Driver;

namespace FlowMindsApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class DepartmentController(IMongoClient client) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create()
    {

        return Ok();
    }
}
