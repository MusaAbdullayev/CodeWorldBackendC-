using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiHelloBL.DTOs.CategoryDTO;
using ApiHelloBL.DTOs.ProductDTO;

namespace ApiHelloBL.Services.ProductService
{
    public interface IProductService
    {

        Task<IEnumerable<ProductGetDTO>> GetAsync();
        Task<ProductGetDTO> GetByIdAsync(int id);
        Task CreateAsync(ProductCreateDTO dto);
        Task UpdateAsync(ProductUpdateDTO dto, int id);
        Task Delete(int id);
    }
}
