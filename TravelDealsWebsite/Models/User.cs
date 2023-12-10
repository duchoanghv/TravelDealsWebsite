using TravelDealsWebsite.Models;

namespace TravelDealsWebsite.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public int? TourNum { get; set; }
        public int? BookingNum { get; set; }
        public int? CustomerNum { get; set; }
        public int? SharePercent { get; set; }

        public bool IsAuthenticated(string userName, string pass)
        {
            return UserName == userName && Pass == pass;
        }
    }

    public class MainData
    {
        public bool IsAuthenticated { get; set; }
        public User User { get; set; } = new User();
        public List<BannerSlider> BannerSliders { get; set; } = new List<BannerSlider>();
        public List<Benefit> Benefits { get; set; } = new List<Benefit>();
        public Contact Contact { get; set; } = new Contact();
        public List<News> News { get; set; } = new List<News>();
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<BookContact> BookContacts { get; set; } = new List<BookContact>();
        public List<Tour> Tours { get; set; } = new List<Tour>();
        public int PageNumber { get; set; } = 1;
        public List<Tour> CurrentTours
        {
            get
            {
                return Tours.Skip(5 * (PageNumber  - 1)).Take(5).OrderBy(e => e.Title).ToList();
            }
        }
        public List<BannerSlider> CurrentSliders
        {
            get
            {
                return BannerSliders.Skip(5 * (PageNumber  - 1)).Take(5).OrderBy(e => e.Title).ToList();
            }
        }
        public List<News> CurrentNews
        {
            get
            {
                return News.Skip(5 * (PageNumber - 1)).Take(5).OrderBy(e => e.Title).ToList();
            }
        }
    }
}
