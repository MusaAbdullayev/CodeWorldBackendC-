using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiHelloBL.DTOs.CategoryDTO;
using ApiHelloCore.Entities;
using AutoMapper;

namespace ApiHelloBL.Profiles.CatProfile
{
    public class CategoryProf : Profile
    {
        public CategoryProf()
        {
            CreateMap<CategoryCreateDTO, Category>();
            CreateMap<CategoryUpdateDTO, Category>();
            CreateMap<Category, CategoryGetDTO>();
        }
    }
}
