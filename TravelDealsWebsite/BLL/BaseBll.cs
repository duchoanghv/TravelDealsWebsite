using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TravelDealsWebsite.BLL
{
    public class BaseBll
    {
        public static SqlConnection _dbContext =
                    new SqlConnection("Data Source=HOANGDUC-PC;Initial Catalog=ComputerForSale;integrated Security=True");
    }
}
