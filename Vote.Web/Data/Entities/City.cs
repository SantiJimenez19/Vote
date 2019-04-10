

namespace Vote.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class City
    {
        public int Id { get; set; }

        [Display(Name = "City")]
        public string Name { get; set; }

        [Display(Name = "# Cities")]
        public int cities { get; set; }

    }
}
