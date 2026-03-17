using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiHelloCore.Entities;
using Microsoft.AspNetCore.Http;

namespace ApiHelloBL.DTOs.ProductDTO
{
    public class ProductCreateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public IFormFile Image { get; set; }
        public int Count { get; set; }
        public int CategoryId { get; set; }
    }
}
