using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelDealsWebsite.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Img { get; set; }
        public string PostDay { get; set; }
        public string PostMonth { get; set; }
        public string Title { get; set; }
        public string Site { get; set; }
        public string Author { get; set; }
        public string LinkUrl { get; set; }
        public string Description { get; set; }
        public string View { get; set; }
        public string Like { get; set; }

        [JsonIgnore]
        public List<IFormFile> ImgFiles { get; set; }

    }
}
