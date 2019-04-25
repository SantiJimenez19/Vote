

namespace Vote.Web.Controllers
{
    using Helpers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using Vote.Web.Data;
    using Vote.Web.Data.Entities;

    [Authorize(Roles = "Admin")]
    public class EventsController : Controller
    {
        private readonly IEventRepository eventRepository;
        private readonly IUserHelper userHelper;

        public EventsController(IEventRepository eventRepository,IUserHelper userHelper)
        {
            
            this.eventRepository = eventRepository;
            this.userHelper = userHelper;
        }

        // GET: Events
        public IActionResult Index()
        {
            return View(this.eventRepository.GetAll() ) ;
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("EventNotFound");

            }

            var events = await this.eventRepository.GetByIdAsync(id.Value);
            if (events == null)
            {
                return new NotFoundViewResult("EventNotFound");

            }

            return View(events);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event events)
        {
            if (ModelState.IsValid)
            {

                events.User = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                await this.eventRepository.CreateAsync(events);
                return RedirectToAction(nameof(Index));
            }

            return View(events);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("EventNotFound");

            }

            var events = await this.eventRepository.GetByIdAsync(id.Value);
            if (events == null)
            {
                return new NotFoundViewResult("EventNotFound");

            }

            return View(events);
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Event events)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Pending to change to: this.User.Identity.Name
                    events.User = await this.userHelper.GetUserByEmailAsync("santisuarez1100@gmail.com");
                    await this.eventRepository.UpdateAsync(events);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.eventRepository.ExistAsync(events.Id))
                    {
                        return new NotFoundViewResult("EventNotFound");

                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(events);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("EventNotFound");

            }

            var events = await this.eventRepository.GetByIdAsync(id.Value);
            if (events == null)
            {
                return new NotFoundViewResult("EventNotFound");

            }

            return View(events);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var events = await this.eventRepository.GetByIdAsync(id);
            await this.eventRepository.DeleteAsync(events);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            return Ok(this.eventRepository.GetAll());

        }

        public IActionResult ProductNotFound()
        {
            return this.View();
        }





    }

}