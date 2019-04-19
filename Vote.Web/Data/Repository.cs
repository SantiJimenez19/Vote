
namespace Vote.Web.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;

    public class Repository : IRepository
    {
        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Event> GetEvents()
        {
            return this.context.Events.OrderBy(e => e.Name);
        }

        public Event GetEvent(int id)
        {
            return this.context.Events.Find(id);
        }

        public void AddEvent(Event events)
        {
            this.context.Events.Add(events);
        }

        public void UpdateEvent(Event events)
        {
            this.context.Update(events);
        }

        public void RemoveEvent(Event events)
        {
            this.context.Events.Remove(events);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }

        public bool EventExists(int id)
        {
            return this.context.Events.Any(e => e.Id == id);
        }
    }

}

