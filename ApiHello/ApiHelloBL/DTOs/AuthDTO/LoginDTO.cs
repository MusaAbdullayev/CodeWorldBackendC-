using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiHelloBL.DTOs.AuthDTO
{
    public class LoginDTO
    {
        public string UsernameorEmail {  get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
