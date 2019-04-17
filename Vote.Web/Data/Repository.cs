
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

        public IEnumerable<Event> GetProducts()
        {
            return this.context.Events.OrderBy(e => e.Name);
        }

        public Event GetProduct(int id)
        {
            return this.context.Events.Find(id);
        }

        public void AddProduct(Event product)
        {
            this.context.Events.Add(product);
        }

        public void UpdateProduct(Event product)
        {
            this.context.Update(product);
        }

        public void RemoveProduct(Event product)
        {
            this.context.Events.Remove(product);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }

        public bool ProductExists(int id)
        {
            return this.context.Events.Any(e => e.Id == id);
        }
    }



}
}
