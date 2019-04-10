using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vote.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Result
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "# Candidates")]
        public int Candidates { get; set; }


        [Display(Name = "# Votes")]
        public int Votes { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }


        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }



    }
}