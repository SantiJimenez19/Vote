
namespace Vote.Web.Data
{
    using Entities;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Helpers;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private readonly Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();

        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userHelper.GetUserByEmailAsync("santisuarez1100@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Santiago",
                    LastName = "Jimenez",
                    Email = "santisuarez1100@gmail.com",
                    UserName = "santisuarez1100@gmail.com",
                    PhoneNumber = "3128545263"
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }


            if (!this.context.Events.Any())
            {
                this.AddEvents("¿Esta a favor del Aborto?", "¿Cree usted que el aborto es algo necesario para las mujeres?", user);
                this.AddEvents("El nuevo edificio ambiental", "Se planea construir en el centro de la ciudad de barcelona el primer edicio con material ambiental", user);
                await this.context.SaveChangesAsync();
            }

        }

        private void AddEvents(string name, string description, User user)
        {
            this.context.Events.Add(new Event
            {
                Name = name,
                Description = description,
                User = user

            });

        }
    }
}