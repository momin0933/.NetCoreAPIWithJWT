using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TestAPI.Core.Models;
using TestAPI.Core.DataLayer.Interface;
using TestAPI.Core.DataLayer.Repository;

namespace KisokAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;      
        private IUserRepository _userrepository;
        public TokenController(IConfiguration config, TestDbContext context)
        {
            _configuration = config;         
            _userrepository = new UserRepository();
            //_IDapperService = dapperService;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserAccount _userData)
        {
            if (_userData != null && _userData.userId != null && _userData.password != null)
            {
                var user = await GetUser(_userData.userId, _userData.password);

                if (user != null)
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    //create claims details based on the user information
                    var claims = new[] {

                        //new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        //new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        //new Claim("UserLogin", user.UserLogin.ToString()),
                        //new Claim("FullName", user.FullName.ToString()),                       
                        //new Claim("Email", user.Email.ToString())
                        new Claim(ClaimTypes.NameIdentifier,user.userId),                        
                        new Claim(ClaimTypes.GivenName,user.fullName),
                        //new Claim(ClaimTypes.Surname,user.FullName),
                        new Claim(ClaimTypes.Role,user.userrole),
                    };

                  
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(15),
                        signingCredentials: signIn);
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
                    //return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<UserAccount> GetUser(string UserLogin, string UserPassword)
        {

            // UserPassword = EncryptDecrypt.Encrypt(UserPassword);

            // SqlDataClass sqlData = new SqlDataClass();
            // var UserProjectList = _IDapperService.GetAllByQuery<VwUserDetails>(sqlData.GetUserInfo(UserLogin, UserPassword));
            return  _userrepository.GetByUserIdandPassword(UserLogin, UserPassword);
            //return await _userrepository.UserAccounts.FirstOrDefaultAsync(u => u.userId == UserLogin && u.password == UserPassword);
            //UserAccount user = new UserAccount();
            //user.UserId = "momin";
            //user.Password = "1234";
            //user.UserName = "momin";
            //user.UserRole = "sysadmin";
            //return user;
        }
    }
}
