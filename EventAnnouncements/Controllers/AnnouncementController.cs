using Microsoft.AspNetCore.Mvc;
using EventAnnouncements.Services;
using EventAnnouncements.Models;

namespace EventAnnouncements.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly AnnouncementService _announcementService;

        public AnnouncementController(AnnouncementService announcementService)
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

    }
}
