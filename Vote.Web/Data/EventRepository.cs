

namespace Vote.Web.Data
{
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        private readonly DataContext context;

        public EventRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable GetallWithUsers()
        {
            return this.context.Events.Include(e => e.User);
        }
    }
}
