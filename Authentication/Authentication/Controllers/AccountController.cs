﻿using Authentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IConfiguration _config;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(
            IConfiguration config,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager
            )
        {
            _config = config;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Login login)
        {

            var user = new IdentityUser
            {
                UserName = login.UserName
            };

            var currentUser = await _userManager.FindByNameAsync(login.UserName);
            var roles = await _userManager.GetRolesAsync(currentUser);

            var result = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, false);

            if (result.Succeeded)
            {
                var token = Generate(user,roles);

                var data = new TokenModel { User = user, Token = token, Roles = roles };

                return Ok(data);
            }

            return BadRequest(new { message = "Invalid User Credentials" });

        }

        private string Generate(IdentityUser user, IList<string> roles)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };
             
            foreach (var r in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, r));
            }

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires:DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
