using System.Web.Mvc;

namespace GiveCampStarterSite.Controllers
{
    using System;
    using System.Linq;

    using GiveCampStarterSite.Models;
    using GiveCampStarterSite.ViewModel;

    public class HomeController : Controller
    {
        private readonly GiveCampEntities context = new GiveCampEntities();

        public ActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.PageContent = context.Pages.Where(x => x.Title == "Home").FirstOrDefault();
            model.Posts = context.Posts
                    .Where(x => x.PublishDate >= DateTime.Today)
                    .OrderByDescending(x => x.PublishDate);

            return View(model);
        }

        public ActionResult About()
        {
            var model = new HomeAboutViewModel();
            model.PageContent = context.Pages.Where(x => x.Title == "About").FirstOrDefault();

            return View(model);
        }
    }
}
