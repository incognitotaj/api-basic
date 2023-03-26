using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    public class VersionedApiController : BaseApiController
    {
    }
}
