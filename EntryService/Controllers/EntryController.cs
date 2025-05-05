using EntryService.Dtos;
using EntryService.Entities;
using EntryService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EntryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EntryController : ControllerBase
    {
        private readonly IEntryService _entryService;

        public EntryController(IEntryService entryService)
        {
            _entryService = entryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entries = await _entryService.GetAllAsync();
            return Ok(entries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entry = await _entryService.GetByIdAsync(id);
            if (entry == null)
                return NotFound();
            return Ok(entry);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEntryDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // 👈 token'dan alıyoruz
            var username = User.FindFirstValue(ClaimTypes.Name);

            if (userId == null || username == null)
                return Unauthorized();

            var entry = new Entry
            {
                Title = dto.Title,
                Content = dto.Content,
                UserId = int.Parse(userId),
                Username = username,
                CreatedAt = DateTime.UtcNow
            };

            await _entryService.CreateEntryAsync(entry);
            return StatusCode(201);
        }
    }
}
