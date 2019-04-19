

namespace Vote.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using Vote.Web.Data;
    using Vote.Web.Data.Entities;

    public class EventsController : Controller
    {
        private readonly IRepository repository;

        public EventsController(IRepository repository)
        {
            this.repository = repository;
        }

        // GET: Events
        public IActionResult Index()
        {
            return View(this.repository.GetEvents());
        }

        // GET: Events/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var events = this.repository.GetEvent(id.Value);

            if (events == null)
            {
                return NotFound();
            }

            return View(events);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event events)
        {
            if (ModelState.IsValid)
            {
                this.repository.AddEvent(events);
                await this.repository.SaveAllAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(events);
        }

        // GET: Events/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var events = this.repository.GetEvent(id.Value);
            if (events == null)
            {
                return NotFound();
            }
            return View(events);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Event events)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    this.repository.UpdateEvent(events);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.repository.EventExists(events.Id))
                    {
                        return NotFound();
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

        // GET: Events/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var events = this.repository.GetEvent(id.Value);

            if (events == null)
            {
                return NotFound();
            }

            return View(events);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> DeleteConfirmed(int id)
        {
            var events = this.repository.GetEvent(id);
            this.repository.RemoveEvent(events);
            await this.repository.SaveAllAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
