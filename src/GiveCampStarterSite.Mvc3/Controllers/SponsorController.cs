using System.Web.Mvc;

namespace GiveCampStarterSite.Controllers
{
    using GiveCampStarterSite.Data;
    using GiveCampStarterSite.Models;
    using GiveCampStarterSite.ViewModel;

    public class SponsorController : Controller
    {
        private readonly ICachedRepository repository;

        public SponsorController(ICachedRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            var model = new SponsorIndexViewModel();
            model.PageContent = repository.Get<Page>(x => x.Id == StaticPage.Sponsor);
            
            return View(model);
        }

    }
}
