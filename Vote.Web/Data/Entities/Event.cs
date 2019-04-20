

namespace Vote.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Event : IEntity
    {

        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        [Required]
        public string Name { get; set; }


        [Required]
        public string Description { get; set; }


       
        [Display(Name = "Number Candidates")]
        public int Candidates { get; set; }


        [Display(Name = "Number Votes")]
        public int Votes { get; set; }


     
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }


        
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public User User { get; set; }


    }
}
