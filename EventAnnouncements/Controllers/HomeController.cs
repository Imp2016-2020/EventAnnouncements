using EventAnnouncements.Models;
using EventAnnouncements.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EventAnnouncements.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly AnnouncementService _announcementService;

        /*public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/
        public HomeController(AnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }
        
        public IActionResult Index()
        {
            var announcements = _announcementService.GetAnnouncements();
            return View(announcements);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                _announcementService.AddAnnouncement(announcement);
                return RedirectToAction("Index");
            }
            return View(announcement);
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
    }
}
