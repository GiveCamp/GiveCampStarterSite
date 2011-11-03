using System.Linq;
using System.Web.Mvc;

namespace GiveCampStarterSite.Controllers
{
    using GiveCampStarterSite.Models;
    using GiveCampStarterSite.ViewModel;

    public class VolunteerController : Controller
    {
        private readonly GiveCampEntities context = new GiveCampEntities();

        public ActionResult Index()
        {
            var model = new VolunteerIndexViewModel();
            model.PageContent = this.context.Pages.Where(x => x.Title == "Volunteer").FirstOrDefault();

            return View(model);
        }

    }
}
