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
            return View(_mainData);
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
