using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiHelloBL.Services.ProductService
{
    public interface IProductService
    {
        Task CreateAsync();
        Task GetAsync();
    }
}
