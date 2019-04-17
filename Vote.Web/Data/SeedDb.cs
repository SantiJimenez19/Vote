
namespace Vote.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    

    public class SeedDb
    {
        private readonly DataContext context;
        private Random random;

        public SeedDb(DataContext context)
        {
            this.context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Events.Any())
            {
                this.AddEvents("¿Esta a favor del Aborto?", "¿Cree usted que el aborto es algo necesario para las mujeres?") ;
                this.AddEvents("El nuevo edificio ambiental", "Se planea construir en el centro de la ciudad de barcelona el primer edicio con material ambiental");
                await this.context.SaveChangesAsync();
            }

        }

        private void AddEvents(string name, string description)
        {
            this.context.Events.Add(new Event
            {
                Name = name,
                Description = description,
                
            });

        }
    }
}