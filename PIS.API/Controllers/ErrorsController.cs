using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PIS.API.Controllers
{
    [Route("api/[controller]/{code}")]

    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
    }
}
