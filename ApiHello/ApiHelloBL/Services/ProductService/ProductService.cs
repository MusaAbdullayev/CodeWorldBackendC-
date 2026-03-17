using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiHelloBL.DTOs.CategoryDTO;
using ApiHelloBL.DTOs.ProductDTO;
using ApiHelloBL.Extensions;
using ApiHelloCore.Entities;
using ApiHelloCore.Repositories;
using ApiHelloDAL.Context;
using ApiHelloDAL.Repositories;
using AutoMapper;

namespace ApiHelloBL.Services.ProductService
{
    public class ProductService(IProductRepository _repo,IMapper _mapper) : IProductService
    {
      
        public async Task CreateAsync(ProductCreateDTO dto)
        {
            // 1.Validasiya (Extensionsda yazdigimiz methodlari istifade edirik)
            if (!dto.Image.IsValidType("image/"))
                throw new Exception("Yanliz sekil formati olmalidir");
            if (!dto.Image.IsValidSize(2048))
                throw new Exception("Sekil olcusu 2mb dan cox ola bilmez");

            // 2. Faylin yuklenmesi(Extensions methodu ile)
            string FileName = await dto.Image.UploadAsync(Directory.GetCurrentDirectory(),"wwwroot","products");

            // 3. Mapping vasitesi ile cevirme edirik
            var product = _mapper.Map<Product>(dto);

            // 4.Sekilin yolunu menimsedirik
            product.ImageUrl = "products/" +FileName;

            // 5.Baza emeliyyatlari
            await _repo.AddAsync(product);
            await _repo.SaveAsync();

        }

        public async Task Delete(int id)
        {
            await _repo.DeleteAsync(id);
            await _repo.SaveAsync();
        }

        public async Task<ProductGetDTO> GetByIdAsync(int id)
        {
            var data = await _repo.GetByIdAsync(id);
            var entity = _mapper.Map<ProductGetDTO>(data);
            return entity;
           
        }

        public async Task UpdateAsync(ProductUpdateDTO dto, int id)
        {
            // 1. Movcud olan datani bazadan tapiriq
            var product = await _repo.GetByIdAsync(id);
            if (product == null) throw new Exception("mehsul movcud deyil");

            // 2. Eger yeni sekil yuklenibse
            if(dto.Image != null)
            {
                //Validasiya
                if (!dto.Image.IsValidType("image/"))
                    throw new Exception("Yanliz sekil formati olmalidir");
                if (!dto.Image.IsValidSize(2048))
                    throw new Exception("Sekil olcusu 2mb dan cox ola bilmez");

                //kohne sekili serverden silek
                if(!string.IsNullOrEmpty(product.ImageUrl))
                {
                    FileExtensions.DeleteFile(product.ImageUrl,Directory.GetCurrentDirectory() ,"wwwroot","products");
                }

                // yeni sekli yukleyirik 
                string newFileName = await dto.Image.UploadAsync(Directory.GetCurrentDirectory(), "wwwroot", "products");
                product.ImageUrl = "products/" + newFileName;

            }
            //AutoMapper ile diger datalari ceviririk
            _mapper.Map(dto,product);

            //baza emeliyyatlari
            await _repo.SaveAsync();
        }

        public async Task<IEnumerable<ProductGetDTO>> GetAsync()
        {
            var datas = _repo.GetAll();
            var entities = _mapper.Map<IEnumerable<ProductGetDTO>>(datas);
            return entities;
              
        }
    }
}
