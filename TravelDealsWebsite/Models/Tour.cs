﻿using Newtonsoft.Json;
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
        public string ContentImg { get; set; }
        public double? Rate { get; set; }
        public int? Price { get; set; }
        public string Traffic { get; set; }
        public string Type { get; set; }
        public int? Booking { get; set; }
        public int? DayNumbers { get; set; }
        public string Note { get; set; }
        public List<TourDescription> TourDescriptions { get; set; } = new List<TourDescription>();

        [JsonIgnore]
        public List<DayNumbers> DayNumbersList { get; set; } = new List<DayNumbers>() {
            new DayNumbers(){Value = 1, Description = "1 ngày"},
            new DayNumbers(){Value = 2, Description = "2 ngày"},
            new DayNumbers(){Value = 3, Description = "3 ngày"},
            new DayNumbers(){Value = 4, Description = "4 ngày"},
            new DayNumbers(){Value = 5, Description = "Từ 5 ngày"},
            };

        [JsonIgnore]
        public List<IFormFile> ImgFiles { get; set; }
        [JsonIgnore]
        public List<IFormFile> ContentImgFiles { get; set; }
    }

    public class TourDescription
    {
        public int Id { get; set; }
        public int? TourId { get; set; }
        public string Description { get; set; }
    }

    public class DayNumbers
    {
        public int Value { get; set; }
        public string Description { get; set; }
    }
}
