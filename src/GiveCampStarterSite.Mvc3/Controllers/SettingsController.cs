using System.Web.Mvc;

namespace GiveCampStarterSite.Controllers
{
    using System;

    using GiveCampStarterSite.ViewModel;

    public class SettingsController : Controller
    {

        public ActionResult Index()
        {
            var model = new SettingsIndexViewModels();
            model.Settings = SiteSettings.Instance;

            return View(model.Settings);
        }

        public ActionResult General()
        {
            var model = new SiteSettingsViewModel();

            var siteSettings = SiteSettings.Instance;



            model.Title = siteSettings.Title;
            model.SubTitle = siteSettings.SubTitle;
            model.Theme = siteSettings.Theme;
            model.Themes = SiteSettings.AvailableThemes();
            model.Description = siteSettings.Description;
            model.StartDate = siteSettings.StartDate.HasValue ? (DateTime)siteSettings.StartDate : DateTime.Now;

            return this.View(model);
        }

    }
}
