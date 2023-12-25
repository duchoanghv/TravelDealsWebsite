using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TravelDealsWebsite.BLL;
using TravelDealsWebsite.Models;
using TravelDealsWebsite.Utility;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Hosting.Internal;

namespace TravelDealsWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductBll _productBll = new ProductBll();
        private readonly IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
        private MainData _mainData = new MainData();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            InitData();
            HttpContext.Session.SetObjectAsJson("MainData", _mainData);
            return View(_mainData);
        }
        public IActionResult Reset()
        {
            var mainData = _productBll.GetAllData();
            ViewData["MainData"] = mainData;
            HttpContext.Session.SetObjectAsJson("MainData", mainData);
            return View("Index", mainData);
        }

        public IActionResult Service()
        {
            InitData();
            return View(_mainData);
        }

        public IActionResult Contact()
        {
            InitData();
            return View(_mainData.Contact);
        }

        public IActionResult News()
        {
            InitData();
            ViewData["NewsAll"] = _mainData.News;
            _mainData.PageNumber = 1;
            _mainData.PageSize = 3;
            HttpContext.Session.SetObjectAsJson("PaggingData", _mainData);
            return View(_mainData);
        }

        [HttpGet]
        [Route("newscat/{category?}")]
        public IActionResult News(string category)
        {
            Dictionary<string, string> dics = new Dictionary<string, string>() {
                {"diem-du-lich", "Điểm du lịch" },
                {"kinh-nghiem", "Kinh nghiệm" },
                {"anh-dep", "Ảnh đẹp" },
                {"blog", "Blog" },
                {"khac", "Khác" },
            };

            category = dics.SingleOrDefault(e => e.Key == category).Value;
            InitData();
            ViewData["NewsAll"] = _mainData.News;
            if (!string.IsNullOrEmpty(category))
                _mainData.News = _mainData.News.Where(e => e.Category == category).ToList();

            _mainData.PageNumber = 1;
            _mainData.PageSize = 3;
            HttpContext.Session.SetObjectAsJson("PaggingData", _mainData);
            return View(_mainData);
        }

        [HttpGet]
        [Route("news/{linkId?}")]
        public IActionResult DetailNews(string linkId)
        {
            InitData();
            ViewData["NewsAll"] = _mainData.News;

            if (!string.IsNullOrEmpty(linkId))
                _mainData.News = _mainData.News.Where(e => e.LinkUrl == linkId).ToList();

            _mainData.PageNumber = 1;
            _mainData.PageSize = 3;
            HttpContext.Session.SetObjectAsJson("PaggingData", _mainData);
            return View("News", _mainData);
        }

        [HttpGet]
        public PartialViewResult GoPageNews()
        {
            var mainData = HttpContext.Session.GetObjectFromJson<MainData>("PaggingData") ?? _productBll.GetAllData();
            mainData.PageSize += 5;
            HttpContext.Session.SetObjectAsJson("PaggingData", mainData);
            return PartialView("_NewsList_PartialView", mainData.CurrentNews);
        }

        public IActionResult Manage()
        {
            InitData();
            return View(_mainData);
        }
        [HttpPost]
        public IActionResult Login(string userName, string pass)
        {
            var mainData = HttpContext.Session.GetObjectFromJson<MainData>("MainData") ?? _productBll.GetAllData();
            mainData.IsAuthenticated = mainData.User.IsAuthenticated(userName, pass);
            HttpContext.Session.SetObjectAsJson("MainData", mainData);
            ViewData["MainData"] = mainData;
            return View("Manage", mainData);
        }

        private void InitData()
        {
            _mainData = HttpContext.Session.GetObjectFromJson<MainData>("MainData") ?? _productBll.GetAllData();
            ViewData["MessagerUrl"] = _mainData.Contact.MessagerUrl + "?ref=" + _httpContextAccessor.HttpContext?.Request?.GetDisplayUrl();
            ViewData["MainData"] = _mainData;
            ViewData["CurrentUrl"] = _httpContextAccessor.HttpContext?.Request?.GetDisplayUrl();
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public IActionResult AddBookContact(BookContact model)
        {
            InitData();
            _mainData.BookContacts = _productBll.AddBookContact(model);
            HttpContext.Session.SetObjectAsJson("MainData", _mainData);
            return View("Contact", _mainData.Contact);
        }
    }
}
