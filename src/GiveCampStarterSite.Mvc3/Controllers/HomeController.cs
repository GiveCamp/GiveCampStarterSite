using System.Web.Mvc;

namespace GiveCampStarterSite.Controllers
{
    using System;
    using System.Linq;

    using GiveCampStarterSite.Data;
    using GiveCampStarterSite.Models;
    using GiveCampStarterSite.ViewModel;

    public class HomeController : Controller
    {
        private readonly ICachedRepository repository;

        public HomeController(ICachedRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.PageContent = repository.Get<Page>(x => x.Title == "Home");

            model.Posts =
                repository.Find<Post>(x => x.PublishDate >= DateTime.Today).OrderByDescending(x => x.PublishDate);

            return View(model);
        }

        public ActionResult About()
        {
            var model = new HomeAboutViewModel();
            model.PageContent = repository.Get<Page>(x => x.Title == "About");
            
            return View(model);
        }
    }
}
