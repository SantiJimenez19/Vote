
namespace Vote.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;

    using Vote.Web.Data;


    [Route("api/[Controller]")]
    public class EventsController : Controller
    {
        private readonly IEventRepository eventRepository;

        public EventsController(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            return Ok(this.eventRepository.GetallWithUsers());

        }
    }
}
