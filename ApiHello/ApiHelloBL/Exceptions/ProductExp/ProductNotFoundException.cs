using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiHelloBL.Exceptions.ProductExp
{
    public class ProductNotFoundException:Exception ,IBaseException
    {
        public int code => StatusCodes.Status404NotFound;

        public string Errormessage { get; }
        public ProductNotFoundException()
        {
            Errormessage = "Product Not Found,Please true id ";
        }

        public ProductNotFoundException(string? message) : base(message)
        {
            Errormessage = message;
        }
    }
}
