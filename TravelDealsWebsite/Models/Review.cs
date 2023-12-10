using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelDealsWebsite.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int? Rate { get; set; }
        public string Note { get; set; }
        public string Img { get; set; }
        public DateTime? ReviewDate { get; set; }
    }
}
