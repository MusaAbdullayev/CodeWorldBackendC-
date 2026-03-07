using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiHelloCore.Entities;
using ApiHelloCore.Repositories;
using ApiHelloDAL.Context;

namespace ApiHelloDAL.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApiDbContext _context) : base(_context)
        {
        }
    }
}
