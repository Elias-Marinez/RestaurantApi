using Microsoft.AspNetCore.Mvc;

namespace Restaurant.WebApi.Controllers.Core
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {

    }
}
