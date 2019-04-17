

namespace Vote.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Event
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        [Required]
        public string Description{ get; set; }


        [Required]
        [Display (Name="Number Candidates")]
        public int  Candidates { get; set; }


        [Required]
        [Display(Name = "Number Votes")]
        public int Votes { get; set; }


        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }


        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }





    }
}
