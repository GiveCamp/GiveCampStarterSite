using System.Web.Mvc;

namespace GiveCampStarterSite.Controllers
{
    using GiveCampStarterSite.Data;
    using GiveCampStarterSite.Models;
    using GiveCampStarterSite.ViewModel;

    public class PageController : Controller
    {
        private readonly IRepository repository;

        public PageController(IRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Edit(int id)
        {
            var model = new PageEditModel();
            model.Referrer = Request.UrlReferrer;
            
            var page = repository.Get<Page>(x => x.Id == id);
            model.Page = new EditablePage {Id = id, Title = page.Title, Content = page.Content };

            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(PageEditModel model)
        {
            var page = repository.Get<Page>(x => x.Id == model.Page.Id);

            page.Title = model.Page.Title;
            page.Content = model.Page.Content;

            repository.Save(page);

            repository.Dispose();

            return Redirect(model.Referrer.AbsoluteUri);
        }

    }
}
