using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelDealsWebsite.Models
{
    public class Tour
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public double? Rate { get; set; }
        public int? Price { get; set; }
        public string Traffic { get; set; }
        public string Type { get; set; }
        public int? Booking { get; set; }
        public string Note { get; set; }
        public List<TourDescription> TourDescriptions { get; set; } = new List<TourDescription>();

        [JsonIgnore]
        public List<IFormFile> ImgFiles { get; set; }
    }

    public class TourDescription
    {
        public int Id { get; set; }
        public int? TourId { get; set; }
        public string Description { get; set; }
    }
}
