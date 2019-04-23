
namespace Vote.Common.Models
{
    using Newtonsoft.Json;
    using System;
    public class Event
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("#candidates")]
        public int Candidates { get; set; }

        [JsonProperty("#votes")]
        public int Votes { get; set; }

        [JsonProperty("start date")]
        public DateTime StartDate { get; set; }

        [JsonProperty("end date")]
        public DateTime EndDate { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        public override string ToString()
        {
            return $"{ this.Name} { this.Description}";
   
        }

    }

}

