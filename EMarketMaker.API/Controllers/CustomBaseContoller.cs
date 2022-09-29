using EMarketMaker.Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMarketMaker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseContoller : ControllerBase
    {
        [NonAction]//end point olmadğını belirtmek içim
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            if (response.StatusCode == 204)
                return new ObjectResult(null) { StatusCode = response.StatusCode };

            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
