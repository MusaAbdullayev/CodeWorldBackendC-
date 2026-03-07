using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiHelloBL.DTOs.CategoryDTO;
using ApiHelloCore.Entities;
using ApiHelloCore.Repositories;
using AutoMapper;

namespace ApiHelloBL.Services.CategoryService
{
    public class CategoryService(ICategoryRepository _repo ,IMapper _mapper) : ICategoryService
    {
        public async Task CreateAsync(CategoryCreateDTO dto)
        {
           var data = _mapper.Map<Category>(dto);
            await _repo.AddAsync(data);
            await _repo.SaveAsync();
        }

        public async  Task Delete(int id)
        {
           await _repo.DeleteAsync(id);
           await _repo.SaveAsync();
        }

        public async Task<IEnumerable<CategoryGetDTO>> GetAsync()
        {
           var datas =_repo.GetAll();
           var entities = _mapper.Map<IEnumerable<CategoryGetDTO>>(datas);
            return entities;
        }

        public async Task<CategoryGetDTO> GetByIdAsync(int id)
        {
           var entity = await _repo.GetByIdAsync(id);
            var data = _mapper.Map<CategoryGetDTO>(entity);
            return data;
        }

        public async Task UpdateAsync(CategoryUpdateDTO dto, int id)
        {
            var data = await _repo.GetByIdAsync(id);
            data.Name = dto.Name;
            await _repo.SaveAsync();
        }
    }
}
