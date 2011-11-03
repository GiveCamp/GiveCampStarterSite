using System.Linq;
using System.Web.Mvc;

namespace GiveCampStarterSite.Controllers
{
    using GiveCampStarterSite.Models;
    using GiveCampStarterSite.ViewModel;

    public class SponsorController : Controller
    {
        private readonly GiveCampEntities context = new GiveCampEntities();

        public ActionResult Index()
        {
            var model = new SponsorIndexViewModel();
            model.PageContent = context.Pages.Where(x => x.Title == "Sponsor").FirstOrDefault();
            
            return View(model);
        }

    }
}
