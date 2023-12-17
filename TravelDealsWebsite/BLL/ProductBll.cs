using TravelDealsWebsite.Models;
using Dapper;
using Microsoft.Extensions.Primitives;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

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
            var paramsList = new List<SqlParameter>()
                {
                     new SqlParameter(){ParameterName =  "@Title", SqlDbType= SqlDbType.NVarChar, SqlValue = !string.IsNullOrEmpty(model.Title) ? model.Title : DBNull.Value},
                    new SqlParameter(){ParameterName =  "@Description", SqlDbType= SqlDbType.NVarChar, SqlValue = !string.IsNullOrEmpty(model.Description) ? model.Description : DBNull.Value},
                    new SqlParameter(){ParameterName =  "@Img", SqlDbType= SqlDbType.NVarChar, SqlValue = !string.IsNullOrEmpty(model.Img) ? model.Img : DBNull.Value},
                    new SqlParameter(){ParameterName =  "@ContentImg", SqlDbType= SqlDbType.NVarChar, SqlValue = !string.IsNullOrEmpty(model.ContentImg) ? model.ContentImg : DBNull.Value},
                    new SqlParameter(){ParameterName =  "@Rate", SqlDbType= SqlDbType.Float, SqlValue = model.Rate.HasValue?model.Rate:DBNull.Value },
                    new SqlParameter(){ParameterName =  "@Price", SqlDbType= SqlDbType.Int, SqlValue = model.Price.HasValue?model.Price:DBNull.Value},
                    new SqlParameter(){ParameterName =  "@Traffic", SqlDbType= SqlDbType.NVarChar, SqlValue = !string.IsNullOrEmpty(model.Traffic) ? model.Traffic : DBNull.Value},
                    new SqlParameter(){ParameterName =  "@Type", SqlDbType= SqlDbType.NVarChar, SqlValue = !string.IsNullOrEmpty(model.Type) ? model.Type : DBNull.Value},
                    new SqlParameter(){ParameterName =  "@Booking", SqlDbType= SqlDbType.Int, SqlValue = model.Booking.HasValue?model.Booking:DBNull.Value },
                    new SqlParameter(){ParameterName =  "@Note", SqlDbType= SqlDbType.NVarChar, SqlValue = !string.IsNullOrEmpty(model.Note) ? model.Note : DBNull.Value},
                    new SqlParameter(){ParameterName =  "@DayNumbers", SqlDbType= SqlDbType.Int, SqlValue = model.DayNumbers.HasValue?model.DayNumbers:DBNull.Value },
                    new SqlParameter(){ParameterName =  "@Id", SqlDbType= SqlDbType.Int, SqlValue = model.Id},
                }.ToArray();

            using (var con = new SqlConnection(_dbContext.ConnectionString))
            {
                using (var cmd = new SqlCommand(@"UPDATE [Tour] SET Title=@Title,Description=@Description,Img=@Img,ContentImg=@ContentImg,Rate=@Rate,Price=@Price,Traffic=@Traffic,
                                                                    Type=@Type,Booking=@Booking,Note=@Note,DayNumbers=@DayNumbers WHERE Id=@Id", con))
                {
                    con.Open();
                    cmd.Parameters.AddRange(paramsList);
                    cmd.ExecuteNonQuery();
                }
            }
            return _dbContext.Query<Tour>("select * from Tour").ToList();
        }

        public List<Tour> AddTour(Tour model)
        {
            var paramsList = new List<SqlParameter>()
                {
                    new SqlParameter(){ParameterName =  "@Title", SqlDbType= SqlDbType.NVarChar, SqlValue = !string.IsNullOrEmpty(model.Title) ? model.Title : DBNull.Value},
                    new SqlParameter(){ParameterName =  "@Description", SqlDbType= SqlDbType.NVarChar, SqlValue = !string.IsNullOrEmpty(model.Description) ? model.Description : DBNull.Value},
                    new SqlParameter(){ParameterName =  "@Img", SqlDbType= SqlDbType.NVarChar, SqlValue = !string.IsNullOrEmpty(model.Img) ? model.Img : DBNull.Value},
                    new SqlParameter(){ParameterName =  "@ContentImg", SqlDbType= SqlDbType.NVarChar, SqlValue = !string.IsNullOrEmpty(model.ContentImg) ? model.ContentImg : DBNull.Value},
                    new SqlParameter(){ParameterName =  "@Rate", SqlDbType= SqlDbType.Float, SqlValue = model.Rate.HasValue?model.Rate:DBNull.Value },
                    new SqlParameter(){ParameterName =  "@Price", SqlDbType= SqlDbType.Int, SqlValue = model.Price.HasValue?model.Price:DBNull.Value},
                    new SqlParameter(){ParameterName =  "@Traffic", SqlDbType= SqlDbType.NVarChar, SqlValue = !string.IsNullOrEmpty(model.Traffic) ? model.Traffic : DBNull.Value},
                    new SqlParameter(){ParameterName =  "@Type", SqlDbType= SqlDbType.NVarChar, SqlValue = !string.IsNullOrEmpty(model.Type) ? model.Type : DBNull.Value},
                    new SqlParameter(){ParameterName =  "@Booking", SqlDbType= SqlDbType.Int, SqlValue = model.Booking.HasValue?model.Booking:DBNull.Value },
                    new SqlParameter(){ParameterName =  "@Note", SqlDbType= SqlDbType.NVarChar, SqlValue = !string.IsNullOrEmpty(model.Note) ? model.Note : DBNull.Value},
                    new SqlParameter(){ParameterName =  "@DayNumbers", SqlDbType= SqlDbType.Int, SqlValue = model.DayNumbers.HasValue?model.DayNumbers:DBNull.Value },
                }.ToArray();

            using (var con = new SqlConnection(_dbContext.ConnectionString))
            {
                using (var cmd = new SqlCommand(@"INSERT INTO [Tour] ([Title],[Description],[Img],[ContentImg],[Rate],[Price],[Traffic],[Type],[Booking],[Note],[DayNumbers]) 
                                                  VALUES(@Title,@Description,@Img,@ContentImg,@Rate,@Price,@Traffic,@Type,@Booking,@Note,@DayNumbers)", con))
                {
                    con.Open();
                    cmd.Parameters.AddRange(paramsList);
                    cmd.ExecuteNonQuery();
                }
            }
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
