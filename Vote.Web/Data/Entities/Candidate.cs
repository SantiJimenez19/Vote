


namespace Vote.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Candidate : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        [Required]
        public string Name { get; set; }

        public  string Proposal { get; set; }

        public int  Votes { get; set; }

        public User User { get; set; }

    }
}
