namespace GiveCampStarterSite.ViewModel
{
    using System.Collections.Generic;

    using GiveCampStarterSite.Models;

    public class HomeIndexViewModel
    {
        public Page PageContent { get; set; }

        public IEnumerable<Post> Posts { get; set; }
    }

    public class HomeAboutViewModel
    {
        public Page PageContent { get; set; }
    }
}