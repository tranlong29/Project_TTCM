using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Project_TTCM.Datas;
using Project_TTCM.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Project_TTCM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly MyDBContext _context;
        private IConfiguration _configuration;

        public TokenController(IConfiguration configuration, MyDBContext context)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (loginDTO != null && loginDTO.Username != null && loginDTO.Password != null)
            {
                var user = _context.Customers.FirstOrDefault(p =>

                                p.Username == loginDTO.Username && p.Password == loginDTO.Password && p.Admin == 0
                            );
                if (user != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub,_configuration["AppSettings:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                        new Claim("Id", user.Id.ToString()),
                        new Claim("UserName", user.Username),
                        new Claim("Password", user.Password)
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:SecretKey"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                            _configuration["AppSettings:Issuer"],
                            _configuration["AppSettings:Audience"],
                            claims,
                            expires:DateTime.Now.AddDays(2),
                            signingCredentials: signIn
                        );
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid username/password");
                }


                
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost("loginAmin")]
        public async Task<IActionResult> Admin(LoginDTO loginDTO)
        {
            if (loginDTO != null && loginDTO.Username != null && loginDTO.Password != null)
            {
                var user = _context.Customers.FirstOrDefault(p =>

                                p.Username == loginDTO.Username && p.Password == loginDTO.Password && p.Admin == 1
                            );
                if (user != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub,_configuration["AppSettings:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                        new Claim("Id", user.Id.ToString()),
                        new Claim("UserName", user.Username),
                        new Claim("Password", user.Password)
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:SecretKey"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                            _configuration["AppSettings:Issuer"],
                            _configuration["AppSettings:Audience"],
                            claims,
                            expires: DateTime.Now.AddDays(2),
                            signingCredentials: signIn
                        );
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid username/password");
                }



            }
            else
            {
                return BadRequest();
            }

        }

    }
}
