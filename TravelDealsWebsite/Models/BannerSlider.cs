using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelDealsWebsite.Models
{
    public class BannerSlider
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }

        [JsonIgnore]
        public List<IFormFile> ImgFiles { get; set; }
    }
}
