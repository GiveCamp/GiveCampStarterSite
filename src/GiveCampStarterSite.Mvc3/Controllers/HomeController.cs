using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GiveCampStarterSite.Controllers
{
    using GiveCampStarterSite.ServiceContracts;

    public class HomeController : Controller
    {
        private IMessageService MessageService { get; set; }

        public HomeController(IMessageService messageService)
        {
            MessageService = messageService;
        }

        public ActionResult Index()
        {
            ViewBag.Message = MessageService.HomePageMessage;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
