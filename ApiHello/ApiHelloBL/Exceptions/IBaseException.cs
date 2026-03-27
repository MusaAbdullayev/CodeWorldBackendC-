using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiHelloBL.Exceptions
{
    public interface IBaseException
    {
        int code { get; }
        string Errormessage { get; }
    }
}
