using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiHelloBL.DTOs.CategoryDTO;

namespace ApiHelloBL.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryGetDTO>> GetAsync();
        Task<CategoryGetDTO> GetByIdAsync (int id);
        Task CreateAsync(CategoryCreateDTO dto);
        Task UpdateAsync(CategoryUpdateDTO dto,int id);
        Task Delete(int id);
    }
}
