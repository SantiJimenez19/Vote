
namespace Vote.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;
    using Data.Entities;

    public class CandidateViewModel : Candidate
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }


    }
}
