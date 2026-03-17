using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiHelloBL.DTOs.AuthDTO
{
    public class RegisterDTO
    {
        [Required,MaxLength(64)]
        public string FullName { get; set; }
        [Required,MaxLength(64),DataType(DataType.EmailAddress),EmailAddress]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required,MaxLength (64)]
        public string UserName { get; set; }
        [Required,DataType(DataType.Password),Compare(nameof(Password))]
        public string RePassword { get; set; }
    }
}
