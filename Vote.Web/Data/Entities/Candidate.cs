

namespace Vote.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Candidate
    {
        public int Id { get; set; }

        [Display(Name = "Candidate")]
        public string Name { get; set; }

        public string Proposal { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Display(Name = "# Votes")]
        public int Votes {get; set; }

    }
}
