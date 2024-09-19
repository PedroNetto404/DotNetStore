using DotNetStore.Api.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DotNetStore.Api.Controllers;

public sealed class OrdersController : ApiController
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByAsync(Guid id)
    {
        return Ok(id);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(
        GetOrdersRequest request
    )
    {
        return Ok(request);
    }
}