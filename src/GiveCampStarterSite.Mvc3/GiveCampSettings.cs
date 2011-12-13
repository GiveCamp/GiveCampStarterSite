namespace GiveCampStarterSite
{
    using System;
    using System.Web;

    using GiveCampStarterSite.Data;
    using GiveCampStarterSite.Models;

    public class GiveCampSettings
    {
        private const int DefaultId = 1; 
        private readonly IRepository repository;
        
        public GiveCampSettings()
        {
            repository = new EntityFrameworkRepository();
            var settings = repository.Get<EventSetting>(x => x.Id == DefaultId);


            HttpRuntime.Cache.Insert("Settings", settings, null, DateTime.Now.AddMinutes(10d), System.Web.Caching.Cache.NoSlidingExpiration);
        }

        public string Title
        {
            get
            {
                return this.GetSettings().Title;
            }
        }

        private EventSetting GetSettings()
        {
            var item = HttpRuntime.Cache.Get("Settings") as EventSetting;
            if (item == null)
            {
                var settings = repository.Get<EventSetting>(x => x.Id == DefaultId);
                HttpRuntime.Cache.Insert("Settings", settings, null, DateTime.Now.AddMinutes(10d), System.Web.Caching.Cache.NoSlidingExpiration);
            }

            return HttpRuntime.Cache.Get("Settings") as EventSetting;
        }
    }
}