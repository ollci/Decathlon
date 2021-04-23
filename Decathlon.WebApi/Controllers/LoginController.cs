using Decathlon.WebApi.Models;
using Entity.Library.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Decathlon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        readonly DecathlonDbContext _context;
        readonly IConfiguration _configuration;
        public LoginController(DecathlonDbContext content, IConfiguration configuration)
        {
            _context = content;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<Token> Login([FromForm] UserLogin userLogin)
        {
            User user = await _context.Users.FirstOrDefaultAsync(x => x.Email == userLogin.Email && x.Password == userLogin.Password);
            if (user != null)
            {
                TokenHandler tokenHandler = new TokenHandler(_configuration);
                Token token = tokenHandler.CreateAccessToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndDate = token.Expiration.AddHours(1);
                await _context.SaveChangesAsync();

                return token;
            }
            return null;
        }
    }
}
