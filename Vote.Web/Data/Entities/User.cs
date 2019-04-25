
namespace Vote.Web.Data.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User : IdentityUser
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }


    }
}