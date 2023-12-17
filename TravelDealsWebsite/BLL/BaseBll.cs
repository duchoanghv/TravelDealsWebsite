using System.Data.SqlClient;

namespace TravelDealsWebsite.BLL
{
    public class BaseBll
    {
        public static SqlConnection _dbContext = new SqlConnection("Data Source=HOANGDUC-PC;Initial Catalog=TravelDealsDatabase;integrated Security=True");
        //public static SqlConnection _dbContext = new SqlConnection("Data Source=SQL8006.site4now.net;Initial Catalog=db_aa147b_duchoanghv;Persist Security Info=True;User ID=db_aa147b_duchoanghv_admin;Password=Hoangduc@2412;Encrypt=True");
        //public static SqlConnection _dbContext = new SqlConnection(@"Data Source=localhost\SQLEXPRESS2014;User ID=dienbientours.com;Password=Haiyen@123;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    }
}
