using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiHelloBL.Exceptions.CategoryExp
{
    public class CategoryNotFoundException : Exception, IBaseException
    {
        public int code => StatusCodes.Status404NotFound;

        public string Errormessage { get; }
        public CategoryNotFoundException()
        {
            Errormessage = "Category Not Found,Please true id ";
        }

        public CategoryNotFoundException(string? message) : base(message)
        {
            Errormessage = message;
        }
    }
}
