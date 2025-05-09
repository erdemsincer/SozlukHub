using EntryService.Dtos;
using EntryService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EntryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EntryController : ControllerBase
    {
        private readonly IEntryService _service;

        public EntryController(IEntryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var entry = await _service.GetByIdAsync(id);
            return entry == null ? NotFound() : Ok(entry);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEntryDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var username = User.FindFirstValue(ClaimTypes.Name);

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(username))
                return Unauthorized();

            await _service.CreateAsync(dto, int.Parse(userId), username);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("topic/{topicId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByTopicId(int topicId)
        {
            var entries = await _service.GetEntriesByTopicIdAsync(topicId);
            return Ok(entries);
        }

    }
}
