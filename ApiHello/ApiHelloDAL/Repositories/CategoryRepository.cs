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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApiDbContext _context) : base(_context)
        {
        }
    }
}
