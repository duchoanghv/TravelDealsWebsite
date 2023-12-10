using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelDealsWebsite.Models;
using Dapper;
using static Humanizer.In;
using TravelDealsWebsite.Models;

namespace TravelDealsWebsite.BLL
{
    public class ProductBll : BaseBll
    {
        public MainData GetAllData()
        {
            var data = new MainData();

            data.Contact = _dbContext.Query<Contact>("select * from Contact").FirstOrDefault();
            data.Tours = _dbContext.Query<Tour>("select * from Tour").ToList();
            data.BannerSliders = _dbContext.Query<BannerSlider>("select * from BannerSlider").ToList();
            data.User = _dbContext.Query<User>("select * from [User]").FirstOrDefault();
            data.Reviews = _dbContext.Query<Review>("select * from Review").ToList();
            data.Benefits = _dbContext.Query<Benefit>("select * from Benefit").ToList();
            data.News = _dbContext.Query<News>("select * from News").ToList();
            data.BookContacts = _dbContext.Query<BookContact>("select * from BookContact").ToList();

            var tourDetails = _dbContext.Query<TourDescription>("select * from TourDescription").ToList();
            foreach (var tour in data.Tours)
            {
                tour.TourDescriptions = tourDetails.Where(e => e.TourId == tour.Id).ToList();
            }

            return data;
        }

        public List<Tour> GetAllTours()
        {
            var tours = _dbContext.Query<Tour>("select * from Tour").ToList();
            var tourDetails = _dbContext.Query<TourDescription>("select * from TourDescription").ToList();
            foreach (var tour in tours)
            {
                tour.TourDescriptions = tourDetails.Where(e => e.TourId == tour.Id).ToList();
            }

            return tours;
        }

        public void UpdateUser(User model)
        {
            _dbContext.Execute($"update [User] set UserName=N'{model.UserName}',Pass=N'{model.Pass}',TourNum={model.TourNum},BookingNum={model.BookingNum},CustomerNum={model.CustomerNum},SharePercent={model.SharePercent}");
        }

        public void UpdateContact(Contact model)
        {
            _dbContext.Execute($"update [Contact] set Phone=N'{model.Phone}',Email=N'{model.Email}',Address=N'{model.Address}',FacebookUrl=N'{model.FacebookUrl}',TwitterUrl=N'{model.TwitterUrl}',InstagramUrl=N'{model.InstagramUrl}',TiktokUrl=N'{model.TiktokUrl}',WebIcon=N'{model.WebIcon}',WebTitle=N'{model.WebTitle}',MessagerUrl=N'{model.MessagerUrl}'");
        }

        public List<Tour> UpdateTour(Tour model)
        {
            _dbContext.Execute($"update [Tour] set Title=N'{model.Title}',Description=N'{model.Description}',Img=N'{model.Img}',Rate={model.Rate},Price={model.Price},Traffic=N'{model.Traffic}',Type=N'{model.Type}',Booking={model.Booking},Note=N'{model.Note}' where Id={model.Id}");
            return _dbContext.Query<Tour>("select * from Tour").ToList();
        }

        public List<Tour> AddTour(Tour model)
        {
            _dbContext.Execute($"INSERT INTO [Tour] ([Title],[Description],[Img],[Rate],[Price],[Traffic],[Type],[Booking],[Note]) VALUES(N'{model.Title}',N'{model.Description}',N'{model.Img}',{model.Rate},{model.Price},N'{model.Traffic}',N'{model.Type}',{model.Booking},N'{model.Note}')");
            return _dbContext.Query<Tour>("select * from Tour").ToList();
        }

        public List<Tour> DeleteTour(int id)
        {
            _dbContext.Execute($"DELETE FROM [Tour] WHERE Id = {id}");
            return _dbContext.Query<Tour>("select * from Tour").ToList();
        }

        public List<BannerSlider> UpdateSlider(BannerSlider model)
        {
            _dbContext.Execute($"update [BannerSlider] set Title=N'{model.Title}',Description=N'{model.Description}',Img=N'{model.Img}' where Id={model.Id}");
            return _dbContext.Query<BannerSlider>("select * from BannerSlider").ToList();
        }

        public List<BannerSlider> AddSlider(BannerSlider model)
        {
            _dbContext.Execute($"INSERT INTO [BannerSlider] ([Title],[Description],[Img]) VALUES(N'{model.Title}',N'{model.Description}',N'{model.Img}')");
            return _dbContext.Query<BannerSlider>("select * from BannerSlider").ToList();
        }
        
        public List<BookContact> AddBookContact(BookContact model)
        {
            _dbContext.Execute($"INSERT INTO [BookContact] ([Name],[Phone],[Email], [Note], [RequestDate]) VALUES(N'{model.Name}',N'{model.Phone}',N'{model.Email}',N'{model.Note}', GETDATE())");
            return _dbContext.Query<BookContact>("select * from BookContact").ToList();
        } 

        public List<BannerSlider> DeleteSlider(int id)
        {
            _dbContext.Execute($"DELETE FROM [BannerSlider] WHERE Id = {id}");
            return _dbContext.Query<BannerSlider>("select * from BannerSlider").ToList();
        }

        public List<News> UpdateNews(News model)
        {
            _dbContext.Execute($"update [News] set Img=N'{model.Img}',PostDay=N'{model.PostDay}',PostMonth=N'{model.PostMonth}',[Title]=N'{model.Title}',Site=N'{model.Site}',[Author]=N'{model.Author}',LinkUrl=N'{model.LinkUrl}',[Description]=N'{model.Description}',[Like]=N'{model.Like}',[View]=N'{model.View}' where Id={model.Id}");
            return _dbContext.Query<News>("select * from [News]").ToList();
        }

        public List<News> AddNews(News model)
        {
            _dbContext.Execute($"INSERT INTO [News] ([Img],[PostDay],[PostMonth],[Title],[Site],[Author],[LinkUrl],[Description],[Like],[View]) VALUES(N'{model.Img}',N'{model.PostDay}',N'{model.PostMonth}',N'{model.Title}',N'{model.Site}',N'{model.Author}',N'{model.LinkUrl}',N'{model.Description}',N'{model.Like}',N'{model.View}')");
            return _dbContext.Query<News>("select * from [News]").ToList();
        }

        public List<News> DeleteNews(int id)
        {
            _dbContext.Execute($"DELETE FROM [News] WHERE Id = {id}");
            return _dbContext.Query<News>("select * from [News]").ToList();
        }
    }
}
