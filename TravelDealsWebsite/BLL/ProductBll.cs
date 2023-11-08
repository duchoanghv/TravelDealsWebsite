using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelDealsWebsite.Models;
using Dapper;

namespace TravelDealsWebsite.BLL
{
    public class ProductBll : BaseBll
    {
        public List<ProductModel> GetProductsList()
        {
            return _dbContext.Query<ProductModel>("select * from product").ToList();
        }
    }
}
