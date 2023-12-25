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
        [JsonIgnore]
        public string PostDay => PostDate?.Day.ToString();
        [JsonIgnore]
        public string PostMonth => PostDate?.Date.ToString("MM/yyyy");
        public DateTime? PostDate { get; set; } = DateTime.Now;
        public string Title { get; set; }
        public string Note { get; set; }
        public string Site { get; set; }
        public string Category { get; set; }
        public string LinkUrl { get; set; }
        public string Description { get; set; }
        public string View { get; set; }
        public string Like { get; set; }

        [JsonIgnore]
        public List<DropdownItemModel> CategorysList { get; set; } = new List<DropdownItemModel>() {
            new DropdownItemModel(){ValueStr = "Điểm du lịch", Description = "Điểm du lịch"},
            new DropdownItemModel(){ValueStr = "Kinh nghiệm", Description = "Kinh nghiệm"},
            new DropdownItemModel(){ValueStr = "Ảnh đẹp", Description = "Ảnh đẹp"},
            new DropdownItemModel(){ValueStr = "Blog", Description = "Blog"},
            new DropdownItemModel(){ValueStr = "Khác", Description = "Khác"},
            };

        [JsonIgnore]
        public List<IFormFile> ImgFiles { get; set; }

    }
}
