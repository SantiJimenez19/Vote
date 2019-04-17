

namespace Vote.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Event
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description{ get; set; }

        [Display (Name="Number Candidates")]
        public int  Candidates { get; set; }

        [Display(Name = "Number Votes")]
        public int Votes { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }





    }
}
