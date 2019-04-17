using System.Collections.Generic;
using System.Threading.Tasks;
using Vote.Web.Data.Entities;

namespace Vote.Web.Data
{
    public interface IRepository
    {
        void AddProduct(Event product);
        Event GetProduct(int id);
        IEnumerable<Event> GetProducts();
        bool ProductExists(int id);
        void RemoveProduct(Event product);
        Task<bool> SaveAllAsync();
        void UpdateProduct(Event product);
    }
}