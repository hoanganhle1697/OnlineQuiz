using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using OnlineQuiz.Application.DTOs;
using OnlineQuiz.Application.Services.Interfaces;
using OnlineQuiz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace OnlineQuiz.Application.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthServices(SignInManager<AppUser> signInManager,UserManager<AppUser>userManager,IConfiguration configuration,IMapper mapper)
        {
            _signInManager=signInManager;
            _userManager=userManager;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<LoginResult> LoginAsync(SignInDto signInDto)
        {

            var result=await _signInManager.PasswordSignInAsync(signInDto.Email, signInDto.Password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                return new LoginResult { Success = false, Message="Đăng nhập không thành công" };
            }
            var user = await _userManager.FindByEmailAsync(signInDto.Email);
            var roles = await _userManager.GetRolesAsync(user!);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, signInDto.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            authClaims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]!));

            var token = new JwtSecurityToken(
                    issuer:_configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256)
                );
            return new LoginResult { Success = false, Message = "Đăng nhập không thành công" };
        }

        public async Task<IdentityResult> RegisterAsync(SignUpDto signUpDto)
        {
            var user=_mapper.Map<AppUser>(signUpDto);

            return await _userManager.CreateAsync(user, signUpDto.Password);
        }
    }
}
