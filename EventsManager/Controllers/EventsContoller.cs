using EventsManager.Models.Entities;
using EventsManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventsManager.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventsContoller : ControllerBase
    {
        private readonly IEventsService _eventsService;

        public EventsContoller(IEventsService eventsService)
        {
            _eventsService = eventsService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_eventsService.Query());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Event input)
        {
            var resource = _eventsService.Add(input);
            return CreatedAtAction(nameof(GetAll), resource);
        }
    }
}