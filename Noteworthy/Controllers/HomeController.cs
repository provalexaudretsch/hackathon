using Noteworthy.Models;
using Noteworthy.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace Noteworthy.Controllers
{
    //   [Authorize]
    public class HomeController : Controller
    {
        public static ApplicationDbContext Context { get; set; }
        private static User DummyUser = new Models.Entities.User() { Id = 1, DisplayName = "Test User", Email = "test@user.com" };
        private readonly Topic DummyTopic = new Topic() { Id = 1, Name = "Foo" };
        private readonly Topic DummyTopic2 = new Topic() { Id = 2, Name = "Bar" };

        public HomeController()
        {
            if (Context == null)
            {
                Context = new ApplicationDbContext();
            }
            if (Context.SysUsers.Count() == 0)
            {
                Context.SysUsers.Add(DummyUser);
                Context.SaveChanges();
                
                DummyUser = Context.SysUsers.First();
            }
            if (Context.Topics.Count() == 0)
            {
                Context.Topics.AddRange(new[] { DummyTopic, DummyTopic2 });
            }
            if (Context.Notes.Count() == 0)
            {
                var items = new[] {
                new Note() { Timestamp = DateTime.Now, TopicId=1, Id =1, Topic = DummyTopic, User = DummyUser, UserId = DummyUser.Id, Title = "Hello!", AudioS3Path="http://66.90.94.162/ost/lord-of-the-rings-return-of-the-king-howard-shore/xpvwomwdxk/01-a-storm-is-coming.mp3",
                AudioAsText="Voice to text says that you're playing music",
                    } , new Note() { Timestamp = DateTime.Now - new TimeSpan(0, 5,24,1,0),TopicId=1, Id =2, Topic = DummyTopic2, User = DummyUser, UserId = DummyUser.Id, Title = "Hello again!",
                    AudioS3Path="http://66.90.94.162/ost/lord-of-the-rings-return-of-the-king-howard-shore/qtdlbstamg/13-the-fields-of-the-pelennor.mp3"
                    , AudioAsText="Transcription: different music." },
                new Note() { Timestamp = DateTime.Now - new TimeSpan(0, 6,33,2,0),TopicId=1, Id =3, Topic = DummyTopic2, User = DummyUser, UserId = DummyUser.Id, Title = "Older note",
                   IsRead = true, AudioS3Path="http://66.90.94.162/ost/lord-of-the-rings-return-of-the-king-howard-shore/qtdlbstamg/13-the-fields-of-the-pelennor.mp3"
                    , AudioAsText="New line\nhere."}, new Note() {Timestamp = DateTime.Now - new TimeSpan(0, 16,49,6,0),TopicId=1, Id =4, Topic = DummyTopic2, User = DummyUser, UserId = DummyUser.Id, Title = "First note",
                    IsRead = true, AudioS3Path="http://66.90.94.162/ost/lord-of-the-rings-return-of-the-king-howard-shore/thsezppgxh/18-the-grey-havens.mp3"
                    , AudioAsText="Another transcription, another song."
                } };

                Context.Notes.AddRange(items);
            }

            Context.SaveChanges();

        }
        public ActionResult Index()
        {
            return RedirectToAction("Audio");
        }

        [HttpGet]
        public ActionResult Audio()
        {
            var records = Context.Notes.Include(n => n.Topic).Include(n => n.User).OrderByDescending(n => n.Timestamp);
            DummyUser = Context.SysUsers.First();
            var viewModel = new AudioDisplayViewModel(records, DummyUser);

            //Set notes as read.
            foreach (var note in records)
            {
                if (note.IsUnread) {
                    note.IsRead = true;
                var entry = Context.Entry(note);
                entry.State = System.Data.Entity.EntityState.Modified;
                }
            }
            Context.SaveChanges();

            return View(viewModel);

        }

        [HttpPost]
        public JsonResult RecordNote(string title, string content, int userId)
        {
            var machineName = Request.UserHostName;

            var topic = Context.Topics.FirstOrDefault(t => t.Name.ToLower() == title.ToLower());
            if (topic == null)
            {
                topic = new Topic(title);
                Context.Topics.Add(topic);
                Context.SaveChanges();
            }
            var user = Context.SysUsers.Where(u => u.Id == userId).First();
            var note = new Note()
            {
                IsRead = false,
                Timestamp = DateTime.Now,
                Title = machineName,
                TopicId = topic.Id,
                AudioAsText = content,
                UserId = DummyUser.Id,
                User = Context.SysUsers.First(),
            };
            Context.Notes.Add(note);
            Context.SaveChanges();
            return Json(note);
        }
    }
}
