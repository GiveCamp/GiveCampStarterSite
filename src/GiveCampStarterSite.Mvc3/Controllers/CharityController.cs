using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GiveCampStarterSite.Controllers
{
    using GiveCampStarterSite.Models;
    using GiveCampStarterSite.ViewModel;

    public class CharityController : Controller
    {
        private readonly GiveCampEntities context = new GiveCampEntities();

        public ActionResult Index()
        {
            var model = new CharityIndexViewModel();
            model.PageContent = context.Pages.Where(x => x.Title == "Charity").FirstOrDefault();

            return View(model);
        }

        [Authorize]
        public ActionResult Register()
        {
            return this.View();
        }
    }
}
