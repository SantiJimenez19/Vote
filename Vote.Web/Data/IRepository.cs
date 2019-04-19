using System.Collections.Generic;
using System.Threading.Tasks;
using Vote.Web.Data.Entities;

namespace Vote.Web.Data
{
    public interface IRepository
    {
        void AddEvent(Event events);
        Event GetEvent(int id);
        IEnumerable<Event> GetEvents();
        bool EventExists(int id);
        void RemoveEvent(Event events);
        Task<bool> SaveAllAsync();
        void UpdateEvent(Event events);
    }
}