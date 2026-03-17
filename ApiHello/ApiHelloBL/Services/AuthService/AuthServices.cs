using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApiHelloBL.DTOs.AuthDTO;
using ApiHelloCore.Entities;
using ApiHelloCore.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;

namespace ApiHelloBL.Services.AuthService
{
    public class AuthServices(UserManager<User> _userManager, SignInManager<User> _signInManager,
        RoleManager<IdentityRole> _role, IConfiguration _configuration) : IAuthService
    {
        public async Task<string> LoginAsync(LoginDTO dTO)
        {
            var userf = await _userManager.FindByNameAsync(dTO.UsernameorEmail);
            var user = await _userManager.FindByEmailAsync(dTO.UsernameorEmail);
            if (user == null || !await _userManager.CheckPasswordAsync(user, dTO.Password))
                throw new Exception("Email veya sifre sehvdir");
            return await GenerateJWTToken(user);
        }
        private async Task<string> GenerateJWTToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Name , user.UserName),
                new Claim(ClaimTypes.Email , user.Email),

            };
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));


            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials:creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task RegisterAsync(RegisterDTO dto)
        {
           if(dto.Password != dto.RePassword) 
                throw new Exception("Sifreler eyni deyil");
           var UserExists= await _userManager.FindByEmailAsync(dto.Email);
            if (UserExists != null)
                throw new Exception("Bu email artiq istifade olunub");
            var user = new User
            {
                Email = dto.Email,
                UserName = dto.UserName,
                FullName = dto.FullName,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if(!result.Succeeded)
            {
                var errorMsg = string.Join(",", result.Errors.Select(x => x.Description));
            }

            await _userManager.AddToRoleAsync(user, "User");

        }

        public async Task Role()
        {
            foreach(var item in Enum.GetValues(typeof(UserRole)))
            {
                string roleName = item.ToString();
                if(!await _role.RoleExistsAsync(roleName))
                {
                    await _role.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    }
}
