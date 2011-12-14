using System.Web.Mvc;

namespace GiveCampStarterSite.Controllers
{
    using GiveCampStarterSite.Data;
    using GiveCampStarterSite.Models;
    using GiveCampStarterSite.ViewModel;

    public class CharityController : Controller
    {

        private readonly ICachedRepository repository;

        public CharityController(ICachedRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            var model = new CharityIndexViewModel();
            model.PageContent = repository.Get<Page>(x => x.Id == StaticPage.Charity);

            return View(model);
        }

        [Authorize]
        public ActionResult Register()
        {
            return this.View();
        }
    }
}
