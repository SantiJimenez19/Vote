﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vote.Web.Data.Entities
{
    public class Country :IEntity
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Country")]
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string Name { get; set; }

        
    }
}
