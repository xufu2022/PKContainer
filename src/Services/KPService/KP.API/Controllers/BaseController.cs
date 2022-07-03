using Microsoft.AspNetCore.Mvc;

namespace KP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
    }
}