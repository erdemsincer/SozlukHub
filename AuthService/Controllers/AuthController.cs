using AuthService.Data;
using AuthService.Entities;
using AuthService.Models;
using AuthService.Services;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts;
using System.Security.Cryptography;
using System.Text;

namespace AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthDbContext _context;
        private readonly JwtService _jwtService;
        private readonly IPublishEndpoint _publishEndpoint;

        public AuthController(AuthDbContext context, JwtService jwtService, IPublishEndpoint publishEndpoint)
        {
            _context = context;
            _jwtService = jwtService;
            _publishEndpoint = publishEndpoint;
        }

        // 🔐 REGISTER
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var userExists = await _context.Users.AnyAsync(u => u.Email == dto.Email || u.Username == dto.Username);
            if (userExists)
                return BadRequest("Bu email veya kullanıcı adı zaten kullanılıyor.");

            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = HashPassword(dto.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // ✅ Event yayınla
            await _publishEndpoint.Publish(new UserCreatedEvent
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            });

            var token = _jwtService.GenerateToken(user);
            return Ok(token);
        }

        // 🔓 LOGIN
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null || !VerifyPassword(dto.Password, user.PasswordHash))
                return Unauthorized("Hatalı email veya şifre.");

            var token = _jwtService.GenerateToken(user);
            return Ok(token);
        }

        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(sha.ComputeHash(bytes));
        }

        private bool VerifyPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }
    }
}
