/*using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Project_TTCM.Datas;
using Project_TTCM.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Project_TTCM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDBContext _context;
        private readonly AppSettings _appSettings;

        public UserController(MyDBContext context, IOptionsMonitor<AppSettings> optionsMonitor)
        {
            _context = context;
            _appSettings = optionsMonitor.CurrentValue;
        }

        [HttpPost("logintest")]
        public async Task<IActionResult> Validate(LoginDTO loginDTO)
        {
            var user = _context.Customers.FirstOrDefault(p =>

                p.Username == loginDTO.Username && p.Password == loginDTO.Password && p.Admin == 0
            );
            if(user == null)
            {
                return Ok(new ApiReponse
                {
                    Success = false,
                    Message = "Invalid username/password"
                });
            }

            var token = await GenerateToke(user);

            return Ok(new ApiReponse
            {
                Success = true,
                Message = "Authenticate success",
                Data =  token
            });
        }
        private async Task<TokenDTO> GenerateToke(Customer customer)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);

            var tokeDenscription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, customer.Name),
                    new Claim(JwtRegisteredClaimNames.Email, customer.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, customer.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim("UserName", customer.Username),
                    new Claim("Id", customer.Id.ToString()),

                }),

                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
                
            };
            var token = jwtTokenHandler.CreateToken(tokeDenscription);
            var accessToken = jwtTokenHandler.WriteToken(token);
            var refreshToken = GenerateRefreshToken();


            var refreshTokenEntity = new RefreshToken
            {
                Id = Guid.NewGuid(),
                JwtId = token.Id,
                IdUser = customer.Id,
                Token= refreshToken,
                IsActive = false,
                IsRevoked = false,
                IssuedAt = DateTime.UtcNow,
                ExpireAt = DateTime.UtcNow.AddDays(2)
            };

            await _context.AddAsync(refreshTokenEntity);
            await _context.SaveChangesAsync();

            return new TokenDTO
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }
        
        private string GenerateRefreshToken()
        {
            var random = new byte[32];
            using (var  rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);

                return Convert.ToBase64String(random);
            }
        }
        [HttpPost("RenewToken")]
        public async Task<IActionResult> RenewToken(TokenDTO tokenDTO)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);
            var tokenValidateParam = new TokenValidationParameters
            {
                //tự cấp token
                ValidateIssuer = false,
                ValidateAudience = false,

                //ký vào token
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

                ClockSkew = TimeSpan.Zero,

                ValidateLifetime = false //ko kiểm tra token hết hạn
            };
            try
            {
                //task 1: accesstoken valid format
                var tokenInVerification = jwtTokenHandler.ValidateToken(tokenDTO.AccessToken, tokenValidateParam, out var validatedToken);

                //task 2: check alg
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha512, StringComparison.InvariantCultureIgnoreCase);
                    if (!result)//false
                    {
                        return Ok(new ApiReponse
                        {
                            Success = false,
                            Message = "Invalid token"
                        });
                    }
                }

                //task 3: check accessToken expire
                var utcExpireDate = long.Parse(tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

                var expireDate = ConvertUnixTimeToDateTime(utcExpireDate);
                if (expireDate > DateTime.UtcNow)
                {
                    return Ok(new ApiReponse
                    {
                        Success = false,
                        Message = "Access token has not yet expired"
                    });
                }
                // task 4: check refresktoken exist in DB

                var storedToken = _context.RefreshTokens.FirstOrDefault(x => x.Token == tokenDTO.RefreshToken);
                if (storedToken == null)
                {
                    return Ok(new ApiReponse
                    {
                        Success = false,
                        Message = "Refresh token does not exist"
                    });
                }
                // task 5 check refreshtoken is used/revoked
                if (storedToken.IsActive)
                {
                    return Ok(new ApiReponse
                    {
                        Success = false,
                        Message = "Refresh token has been used"
                    });
                }
                if (storedToken.IsRevoked)
                {
                    return Ok(new ApiReponse
                    {
                        Success = false,
                        Message = "Refresh token has been revoked"
                    });
                }

                //task 6: Accesstoken id  == Jwtid in refreshtoken
                var jti = tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
                if (storedToken.JwtId != jti)
                {
                    return Ok(new ApiReponse
                    {
                        Success = false,
                        Message = "Token doesn't match"
                    });
                }
                //update token is used
                storedToken.IsRevoked = true;
                storedToken.IsActive = true;
                _context.Update(storedToken);
                await _context.SaveChangesAsync();

                var user = await _context.Customers.SingleOrDefaultAsync(nd => nd.Id == storedToken.IdUser);
                var token = await GenerateToke(user);

                return Ok(new ApiReponse
                {
                    Success = true,
                    Message = "Renew token success",
                    Data = token
                });

            }
            catch(Exception e)
            {
                return Ok(new ApiReponse
                {
                    Success = false,
                    Message = "Something went wrong"
                });

            }
        }

        private DateTime ConvertUnixTimeToDateTime(long utcExpireDate)
        {
            var dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeInterval.AddSeconds(utcExpireDate).ToUniversalTime();

            return dateTimeInterval;
        }

        [HttpPost("loginAdmin")]
        public async Task<IActionResult> loginAdmin(LoginDTO loginDTO)
        {
            var user = _context.Customers.FirstOrDefault(p =>

                p.Username == loginDTO.Username && p.Password == loginDTO.Password && p.Admin == 1
            );
            if (user == null)
            {
                return Ok(new ApiReponse
                {
                    Success = false,
                    Message = "Invalid username/password"
                });
            }

            var token = await GenerateToke(user);

            return Ok(new ApiReponse
            {
                Success = true,
                Message = "Authenticate success",
                Data = token
            });
        }
    }
}
*/