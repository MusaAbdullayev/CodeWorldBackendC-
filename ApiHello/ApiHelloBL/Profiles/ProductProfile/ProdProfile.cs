using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiHelloBL.DTOs.ProductDTO;
using ApiHelloCore.Entities;
using AutoMapper;

namespace ApiHelloBL.Profiles.ProductProfile
{
    public class ProdProfile:Profile
    {
        public ProdProfile()
        {
            CreateMap<ProductCreateDTO, Product>()
                .ForMember(dest => dest.ImageUrl, opt => opt.Ignore());
            CreateMap<ProductUpdateDTO, Product>()
                .ForMember(dest => dest.ImageUrl, opt => opt.Ignore());
            CreateMap<Product, ProductGetDTO>();
        }
    }
}
