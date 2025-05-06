using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewService.Dtos;
using ReviewService.Services;
using System.Security.Claims;

namespace ReviewService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _service;

        public ReviewController(IReviewService service)
        {
            _service = service;
        }

        // 🔥 Yorum oluştur
        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewDto dto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            await _service.CreateReviewAsync(dto, userId);
            return Ok(new { message = "Yorum başarıyla eklendi." });
        }

        // 🔥 Belirli entry'ye ait yorumlar
        [HttpGet("entry/{entryId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByEntryId(int entryId)
        {
            var result = await _service.GetByEntryIdAsync(entryId);
            return Ok(result);
        }

        // 🔥 Belirli kullanıcıya ait yorumlar
        [HttpGet("user/{userId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var result = await _service.GetByUserIdAsync(userId);
            return Ok(result);
        }
    }
}
