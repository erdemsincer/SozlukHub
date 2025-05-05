using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VoteService.Dtos;
using VoteService.Services;

namespace VoteService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService _service;

        public VoteController(IVoteService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddVote([FromBody] CreateVoteDto dto)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdStr, out var userId))
                return Unauthorized();

            var success = await _service.AddVoteAsync(dto, userId);
            return success ? Ok("Vote added.") : BadRequest("Already voted.");
        }

        [HttpDelete("{entryId}")]
        public async Task<IActionResult> RemoveVote(int entryId)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdStr, out var userId))
                return Unauthorized();

            var success = await _service.RemoveVoteAsync(entryId, userId);
            return success ? Ok("Vote removed.") : NotFound("Vote not found.");
        }

        [HttpGet("{entryId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetVotes(int entryId)
        {
            var result = await _service.GetVoteCountAsync(entryId);
            return Ok(result);
        }
    }
}
