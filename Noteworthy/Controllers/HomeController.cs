using Noteworthy.Models;
using Noteworthy.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Noteworthy.Controllers
{
 //   [Authorize]
    public class HomeController : Controller
    {
        public ApplicationDbContext Context { get; set; }
        private readonly User DummyUser = new Models.Entities.User() { Id = 1, DisplayName = "Test User", Email = "test@user.com" };

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Audio()
        {
            var records = Context.Notes.OrderBy(n => n.Title).ToList();
            var viewModel = new AudioDisplayViewModel(records, DummyUser);
            return View();
        }
    }
}
