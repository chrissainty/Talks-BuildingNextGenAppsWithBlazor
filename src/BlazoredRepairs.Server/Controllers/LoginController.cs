using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BlazoredRepairs.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BlazoredRepairs.Server.Controllers
{
    [ApiController, Route("api")]
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            var result = login.Username == "Planner" && login.Password == "Planner1!" || login.Username == "User" && login.Password == "User1!";

            if (!result) return BadRequest(new LoginResult { Successful = false, Error = "Username and password are invalid." });

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, login.Username));

            if (login.Username == "Planner")
            {
                claims.Add(new Claim(ClaimTypes.Role, "Planner"));
            }

            if (login.Username == "User")
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtExpiryInDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtAudience"],
                claims,
                expires: expiry,
                signingCredentials: creds
            );

            return Ok(new LoginResult { Successful = true, Token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}