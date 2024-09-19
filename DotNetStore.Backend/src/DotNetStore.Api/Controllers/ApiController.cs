using Microsoft.AspNetCore.Mvc;

namespace DotNetStore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiController : ControllerBase;