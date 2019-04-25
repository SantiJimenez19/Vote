
namespace Vote.Web.Controllers.API
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    
    using Web.Data;


    [Route("api/[Controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

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
