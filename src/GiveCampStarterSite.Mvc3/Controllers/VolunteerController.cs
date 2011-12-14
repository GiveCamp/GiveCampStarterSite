using System.Web.Mvc;

namespace GiveCampStarterSite.Controllers
{
    using GiveCampStarterSite.Data;
    using GiveCampStarterSite.Models;
    using GiveCampStarterSite.ViewModel;

    public class VolunteerController : Controller
    {
        private readonly ICachedRepository repository;

        public VolunteerController(ICachedRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            var model = new VolunteerIndexViewModel();
            model.PageContent = repository.Get<Page>(x => x.Id == StaticPage.Volunteer);

            return View(model);
        }

    }
}
