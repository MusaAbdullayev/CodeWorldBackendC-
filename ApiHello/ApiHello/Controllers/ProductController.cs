using ApiHelloBL.DTOs.ProductDTO;
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
            
            return Ok(await _service.GetAsync());
        }
        [HttpGet("byid")]
        public async Task<IActionResult> GetById(int id)
        {
            await _service.GetByIdAsync(id);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Post(ProductCreateDTO dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Put(ProductUpdateDTO dto, int id)
        {
            await _service.UpdateAsync(dto,id);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
