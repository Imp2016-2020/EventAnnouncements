using EventAnnouncements.Models;
using System;
using System.Collections.Generic;

namespace EventAnnouncements.Services
{
    public class AnnouncementService
    {
        private readonly List<Announcement> _announcements;

        public AnnouncementService()
        {
            _announcements = new List<Announcement>
            {
                new Announcement { Id = 1, Title = "Welcome Back!", Description = "Welcome to the new academic year.", DatePosted = DateTime.Now },
                new Announcement { Id = 2, Title = "Holiday Notice", Description = "College will remain closed on Monday.", DatePosted = DateTime.Now.AddDays(-1) }
            };
        }

        public List<Announcement> GetAnnouncements()
        {
            return _announcements;
        }

        public void AddAnnouncement(Announcement announcement)
        {
            announcement.Id = _announcements.Count + 1;
            announcement.DatePosted = DateTime.Now;
            _announcements.Add(announcement);
        }
    }
}