using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using TravelDealsWebsite.BLL;
using TravelDealsWebsite.Models;
using TravelDealsWebsite.Utility;

namespace TravelDealsWebsite.Controllers
{
    public class ManageController : Controller
    {
        private readonly ProductBll _productBll = new ProductBll();
        private IWebHostEnvironment hostingEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
        private MainData _mainData = new MainData();
        private int? _currentItemId = null;
        public ManageController(IWebHostEnvironment _environment)
        {
            hostingEnvironment = _environment;
        }
        public IActionResult User()
        {
            InitData();
            return View(_mainData);
        }

        public IActionResult Contact()
        {
            InitData();
            return View(_mainData);
        }

        public IActionResult Tour()
        {
            InitData();
            _currentItemId = default(int?);
            return View(_mainData);
        }

        public IActionResult News()
        {
            InitData();
            _currentItemId = default(int?);
            return View(_mainData);
        }

        public IActionResult Banner()
        {
            InitData();
            _currentItemId = default(int?);
            return View("Slider", _mainData);
        }

        public IActionResult BookContact()
        {
            InitData();
            return View(_mainData);
        }

        [HttpPost]
        public IActionResult UpdateUser(User model)
        {
            _productBll.UpdateUser(model);
            InitData();
            _mainData.User = model;
            HttpContext.Session.SetObjectAsJson("MainData", _mainData);
            ViewData["MainData"] = _mainData;
            return View("User", _mainData);
        }

        [HttpPost]
        public IActionResult UpdateContact(Contact model)
        {
            InitData();
            model.WebIcon = _mainData.Contact.WebIcon;

            if (model.WebIconFiles != null && model.WebIconFiles.Any())
            {
                model.WebIcon = model.WebIconFiles[0].UploadFile(hostingEnvironment.WebRootPath, "web_icon");
            }
            _productBll.UpdateContact(model);

            _mainData.Contact = model;
            HttpContext.Session.SetObjectAsJson("MainData", _mainData);
            ViewData["MainData"] = _mainData;
            ViewData["MessagerUrl"] = _mainData.Contact.MessagerUrl + "?ref=" + _httpContextAccessor.HttpContext?.Request?.GetDisplayUrl();
            return View("Contact", _mainData);
        }

        [HttpPost]
        public IActionResult UpdateTour(Tour model)
        {
            try
            {
                InitData();
                _currentItemId = HttpContext.Session.GetInt32("CurrentItemId") ?? 0;
                var curentItem = _mainData.Tours.SingleOrDefault(e => e.Id == _currentItemId);
                if (curentItem != null)
                {
                    model.Img = curentItem.Img;
                    model.ContentImg = curentItem.ContentImg;
                }

                if (model.ImgFiles != null && model.ImgFiles.Any())
                {
                    model.Img = model.ImgFiles[0].UploadFile(hostingEnvironment.WebRootPath, "tour");
                }
                if (model.ContentImgFiles != null && model.ContentImgFiles.Any())
                {
                    model.ContentImg = model.ContentImgFiles[0].UploadFile(hostingEnvironment.WebRootPath, "tour");
                }
                model.LinkUrl = model.Title.GenerateLinkId();
                if (_currentItemId > 0)
                {
                    model.Id = _currentItemId.Value;
                    _mainData.Tours = _productBll.UpdateTour(model);
                }
                else
                {
                    _mainData.Tours = _productBll.AddTour(model);
                }

                HttpContext.Session.SetObjectAsJson("MainData", _mainData);
                ViewData["MainData"] = _mainData;
                return View("Tour", _mainData);
            }
            catch (Exception ex)
            {
                return Json(new { Mess = ex.Message });
            }
        }

        [HttpPost]
        public PartialViewResult SelectTour(int? id)
        {
            HttpContext.Session.SetInt32("CurrentItemId", id ?? 0);
            _mainData = HttpContext.Session.GetObjectFromJson<MainData>("MainData") ?? _productBll.GetAllData();
            return PartialView("_Tour_EditPartialView", _mainData.Tours.SingleOrDefault(e => e.Id == id) ?? new Tour());
        }

        [HttpGet]
        public string GetTourNote(int? id)
        {
            _mainData = HttpContext.Session.GetObjectFromJson<MainData>("MainData") ?? _productBll.GetAllData();
            return _mainData.Tours.SingleOrDefault(e => e.Id == id)?.Note;
        }
        [HttpGet]
        public string GetNewsNote(int? id)
        {
            _mainData = HttpContext.Session.GetObjectFromJson<MainData>("MainData") ?? _productBll.GetAllData();
            return _mainData.News.SingleOrDefault(e => e.Id == id)?.Note;
        }

        [HttpPost]
        public PartialViewResult DeleteTour(int id)
        {
            _mainData = HttpContext.Session.GetObjectFromJson<MainData>("MainData") ?? _productBll.GetAllData();
            //var filePath = _mainData.Tours.SingleOrDefault(e => e.Id == id)?.Img;
            //FileExtensions.RemoveFile(hostingEnvironment.WebRootPath + filePath);
            _mainData.Tours = _productBll.DeleteTour(id);
            HttpContext.Session.SetObjectAsJson("MainData", _mainData);
            return PartialView("_Tour_ListPartialView", _mainData);
        }

        [HttpPost]
        public PartialViewResult GoPage(int page)
        {
            _mainData = HttpContext.Session.GetObjectFromJson<MainData>("MainData") ?? _productBll.GetAllData();
            _mainData.PageNumber = page;
            return PartialView("_Tour_ListPartialView", _mainData);
        }


        [HttpPost]
        public IActionResult UpdateSlider(BannerSlider model)
        {
            _mainData = HttpContext.Session.GetObjectFromJson<MainData>("MainData") ?? _productBll.GetAllData();

            _currentItemId = HttpContext.Session.GetInt32("CurrentItemId") ?? 0;
            model.Img = _mainData.BannerSliders.SingleOrDefault(e => e.Id == _currentItemId)?.Img;

            if (model.ImgFiles != null && model.ImgFiles.Any())
            {
                model.Img = model.ImgFiles[0].UploadFile(hostingEnvironment.WebRootPath, "slider");
            }
            _currentItemId = HttpContext.Session.GetInt32("CurrentItemId") ?? 0;
            if (_currentItemId > 0)
            {
                model.Id = _currentItemId.Value;
                _mainData.BannerSliders = _productBll.UpdateSlider(model);
            }
            else
            {
                _mainData.BannerSliders = _productBll.AddSlider(model);
            }

            HttpContext.Session.SetObjectAsJson("MainData", _mainData);
            ViewData["MainData"] = _mainData;
            return View("Slider", _mainData);
        }

        private void InitData()
        {
            _mainData = HttpContext.Session.GetObjectFromJson<MainData>("MainData") ?? _productBll.GetAllData();
            ViewData["MessagerUrl"] = _mainData.Contact.MessagerUrl + "?ref=" + _httpContextAccessor.HttpContext?.Request?.GetDisplayUrl();
            ViewData["MainData"] = _mainData;
        }

        [HttpPost]
        public PartialViewResult SelectSlider(int? id)
        {
            HttpContext.Session.SetInt32("CurrentItemId", id ?? 0);
            _mainData = HttpContext.Session.GetObjectFromJson<MainData>("MainData") ?? _productBll.GetAllData();
            return PartialView("_Slider_EditPartialView", _mainData.BannerSliders.SingleOrDefault(e => e.Id == id) ?? new BannerSlider());
        }

        [HttpPost]
        public PartialViewResult DeleteSlider(int id)
        {
            _mainData = HttpContext.Session.GetObjectFromJson<MainData>("MainData") ?? _productBll.GetAllData();
            _mainData.BannerSliders = _productBll.DeleteSlider(id);
            HttpContext.Session.SetObjectAsJson("MainData", _mainData);
            return PartialView("_Slider_ListPartialView", _mainData);
        }

        [HttpPost]
        public PartialViewResult GoPageSlider(int page)
        {
            _mainData = HttpContext.Session.GetObjectFromJson<MainData>("MainData") ?? _productBll.GetAllData();
            _mainData.PageNumber = page;
            return PartialView("_Slider_ListPartialView", _mainData);
        }


        [HttpPost]
        public PartialViewResult SelectNews(int? id)
        {
            HttpContext.Session.SetInt32("CurrentItemId", id ?? 0);
            _mainData = HttpContext.Session.GetObjectFromJson<MainData>("MainData") ?? _productBll.GetAllData();
            return PartialView("_News_EditPartialView", _mainData.News.SingleOrDefault(e => e.Id == id) ?? new News());
        }

        [HttpPost]
        public IActionResult UpdateNews(News model)
        {
            InitData();
            _currentItemId = HttpContext.Session.GetInt32("CurrentItemId") ?? 0;
            model.Img = _mainData.News.SingleOrDefault(e => e.Id == _currentItemId)?.Img;

            if (model.ImgFiles != null && model.ImgFiles.Any())
            {
                model.Img = model.ImgFiles[0].UploadFile(hostingEnvironment.WebRootPath, "news");
            }
            model.LinkUrl = model.Title.GenerateLinkId();
            model.PostDate ??= DateTime.Now;
            if (_currentItemId > 0)
            {
                model.Id = _currentItemId.Value;
                _mainData.News = _productBll.UpdateNews(model);
            }
            else
            {
                _mainData.News = _productBll.AddNews(model);
            }

            HttpContext.Session.SetObjectAsJson("MainData", _mainData);
            ViewData["MainData"] = _mainData;
            return View("News", _mainData);
        }

        [HttpPost]
        public PartialViewResult DeleteNews(int id)
        {
            _mainData = HttpContext.Session.GetObjectFromJson<MainData>("MainData") ?? _productBll.GetAllData();
            _mainData.News = _productBll.DeleteNews(id);
            HttpContext.Session.SetObjectAsJson("MainData", _mainData);
            return PartialView("_News_ListPartialView", _mainData);
        }

        [HttpPost]
        public PartialViewResult GoPageNews(int page)
        {
            _mainData = HttpContext.Session.GetObjectFromJson<MainData>("MainData") ?? _productBll.GetAllData();
            _mainData.PageNumber = page;
            return PartialView("_News_ListPartialView", _mainData);
        }
    }
}
