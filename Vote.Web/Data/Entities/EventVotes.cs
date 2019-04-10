using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vote.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EventVotes
    {
        public int Id { get; set; }

        [Display(Name = "Event Name")]
        public string Name { get; set; }

        public string Descripption { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }


    }
}