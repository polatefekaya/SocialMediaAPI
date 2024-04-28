using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RosanicSocial.WebAPI.Controllers {
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class CustomControllerBase : ControllerBase {
    }
}
