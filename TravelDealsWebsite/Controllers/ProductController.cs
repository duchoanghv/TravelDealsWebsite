using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TravelDealsWebsite.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult ProductsList(int type)
        {
            return View();
        }
        public IActionResult ProductDetail(int productId)
        {
            return View();
        }
    }
}
