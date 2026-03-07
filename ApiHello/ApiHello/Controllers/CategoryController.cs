using ApiHelloBL.DTOs.CategoryDTO;
using ApiHelloBL.Services.CategoryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiHello.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryService _serivce) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok( await _serivce.GetAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(CategoryCreateDTO dTO)
        {
            await _serivce.CreateAsync(dTO);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Put(CategoryUpdateDTO dto,int id)
        {
            await _serivce.UpdateAsync(dto,id);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _serivce.Delete(id);
            return Ok();
        }
    }
}
