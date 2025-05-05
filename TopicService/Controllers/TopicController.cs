using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TopicService.Entities;
using TopicService.Services;

namespace TopicService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var topics = await _topicService.GetAllAsync();
            return Ok(topics);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var topic = await _topicService.GetByIdAsync(id);
            if (topic == null)
                return NotFound();
            return Ok(topic);
        }

        [HttpPost]
        [Authorize] // sadece giriş yapmış kullanıcılar ekleyebilsin
        public async Task<IActionResult> Create([FromBody] Topic topic)
        {
            await _topicService.CreateTopicAsync(topic);
            return StatusCode(201);
        }
    }
}

