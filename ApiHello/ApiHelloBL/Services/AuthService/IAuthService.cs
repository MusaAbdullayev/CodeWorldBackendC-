using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiHelloBL.DTOs.AuthDTO;

namespace ApiHelloBL.Services.AuthService
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterDTO dto);
        Task<string> LoginAsync(LoginDTO dTO);
        Task Role();
    }
}
