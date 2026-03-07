using ApiHelloBL.Services.ProductService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiHello.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult>Get()
        {
            await _service.GetAsync();
            return Ok();
        }
    }
}
