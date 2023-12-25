using System;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TravelDealsWebsite.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string TiktokUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string WebIcon { get; set; }
        public string WebTitle { get; set; }
        public string MessagerUrl { get; set; }
        public string BankAccount { get; set; }

        [JsonIgnore]
        public List<IFormFile> WebIconFiles { get; set; }

        [JsonIgnore]
        public string WebTitleFont => WebTitle.Substring(0, WebTitle.IndexOf("-")).Trim();

        [JsonIgnore]
        public string WebTitleBack => WebTitle.Substring(WebTitle.IndexOf("-") + 1).Trim();
    }

    public class BookContact
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public DateTime? RequestDate { get; set; }
    }
}
