using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelDealsWebsite.BLL;
using TravelDealsWebsite.Models;
using TravelDealsWebsite.Utility;
using Microsoft.AspNetCore.Http.Extensions;

namespace TravelDealsWebsite.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductBll _productBll = new ProductBll();
        private readonly IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
        public IActionResult ProductsList(int type)
        {
            var mainData = HttpContext.Session.GetObjectFromJson<MainData>("MainData") ?? _productBll.GetAllData();
            ViewData["MainData"] = mainData;
            ViewData["MessagerUrl"] = mainData.Contact.MessagerUrl + "?ref=" + _httpContextAccessor.HttpContext?.Request?.GetDisplayUrl();
            return View(mainData);
        }

        public IActionResult ProductDetail(int productId)
        {
            var mainData = HttpContext.Session.GetObjectFromJson<MainData>("MainData") ?? _productBll.GetAllData();
            ViewData["CurrentUrl"] = _httpContextAccessor.HttpContext?.Request?.GetDisplayUrl();
            ViewData["MainData"] = mainData;
            ViewData["MessagerUrl"] = mainData.Contact.MessagerUrl + "?ref=" + _httpContextAccessor.HttpContext?.Request?.GetDisplayUrl();
            return View(mainData.Tours.SingleOrDefault(e => e.Id == productId));
        }
    }
}
