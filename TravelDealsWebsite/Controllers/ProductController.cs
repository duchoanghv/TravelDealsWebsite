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
        public IActionResult ProductsList()
        {
            var mainData = HttpContext.Session.GetObjectFromJson<MainData>("MainData") ?? _productBll.GetAllData();
            mainData.PageNumber = 1;
            HttpContext.Session.SetObjectAsJson("PaggingData", mainData);
            ViewData["MainData"] = mainData;
            ViewData["MessagerUrl"] = mainData.Contact.MessagerUrl + "?ref=" + _httpContextAccessor.HttpContext?.Request?.GetDisplayUrl();
            return View(mainData);
        }

        [HttpGet]
        [Route("tourcat/{type?}")]
        public IActionResult ProductsList(string type)
        {
            Dictionary<string, string> dics = new Dictionary<string, string>() {
                {"phong-canh-thien-nhien", "Phong cảnh thiên nhiên" },
                {"di-tich-lich-su", "Di tích lịch sử" },
                {"cong-trinh-kien-truc", "Công trình kiến trúc" },
                {"thang-canh-tam-linh", "Thắng cảnh tâm linh" },
                {"khac", "Khác" },
            };

            type = dics.SingleOrDefault(e => e.Key == type).Value;

            var mainData = HttpContext.Session.GetObjectFromJson<MainData>("MainData") ?? _productBll.GetAllData();
            mainData.Tours = mainData.Tours.Where(e => e.Type == type).ToList();
            mainData.PageNumber = 1;
            HttpContext.Session.SetObjectAsJson("PaggingData", mainData);
            ViewData["MainData"] = mainData;
            ViewData["type"] = type;
            ViewData["MessagerUrl"] = mainData.Contact.MessagerUrl + "?ref=" + _httpContextAccessor.HttpContext?.Request?.GetDisplayUrl();
            return View(mainData);
        }

        [HttpGet]
        [Route("tourday/{dayNumbers?}")]
        public IActionResult ProductsListByDays(int dayNumbers)
        {
            var mainData = HttpContext.Session.GetObjectFromJson<MainData>("MainData") ?? _productBll.GetAllData();
            mainData.Tours = mainData.Tours.Where(e => e.DayNumbers == dayNumbers).ToList();
            mainData.PageNumber = 1;
            HttpContext.Session.SetObjectAsJson("PaggingData", mainData);
            ViewData["MainData"] = mainData;
            ViewData["dayNumbers"] = dayNumbers;
            ViewData["MessagerUrl"] = mainData.Contact.MessagerUrl + "?ref=" + _httpContextAccessor.HttpContext?.Request?.GetDisplayUrl();
            return View("ProductsList", mainData);
        }

        [HttpGet]
        [Route("tour/{linkId?}")]
        public IActionResult ProductDetail(string linkId)
        {
            var mainData = HttpContext.Session.GetObjectFromJson<MainData>("MainData") ?? _productBll.GetAllData();
            ViewData["CurrentUrl"] = _httpContextAccessor.HttpContext?.Request?.GetDisplayUrl();
            ViewData["MainData"] = mainData;
            ViewData["MessagerUrl"] = mainData.Contact.MessagerUrl + "?ref=" + _httpContextAccessor.HttpContext?.Request?.GetDisplayUrl();
            return View(mainData.Tours.SingleOrDefault(e => e.LinkUrl == linkId));
        }

        [HttpGet]
        public PartialViewResult GoPage()
        {
            var mainData = HttpContext.Session.GetObjectFromJson<MainData>("PaggingData") ?? _productBll.GetAllData();
            mainData.PageSize += 5;
            HttpContext.Session.SetObjectAsJson("PaggingData", mainData);
            return PartialView("_ProductsList_PartialView", mainData.CurrentTours);
        }
    }
}
