namespace GiveCampStarterSite
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using GiveCampStarterSite.Models;

    public class SiteSettings
    {
        private const int DefaultId = 1; 
        private static readonly object mutex = new object(); 
        private static volatile EventSetting instance;

        private static readonly Data.IRepository Repository = new Data.EntityFrameworkRepository();

        public static EventSetting Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (mutex)
                    {
                        if (instance == null)
                        {
                            instance = LoadSettings();
                        }
                    }
                }                
                return instance;
            }
        }

        public static SelectList AvailableThemes()
        {
            var themePath = HttpContext.Current.Server.MapPath("~/Themes");

            var items = new Dictionary<string, string>();

            foreach (var directory in Directory.GetDirectories(themePath))
            {
                var di = new DirectoryInfo(directory);
                items.Add(di.Name, di.Name);
            }

            items.Add("Default", "Default");

            return new SelectList(items, "Key", "Value");
        }

        public static void SaveSettings(EventSetting settings)
        {
            lock (mutex)
            {
                instance = settings;
                Repository.Save(settings);
            }
        }

        private static EventSetting LoadSettings()
        {
            return Repository.Get<EventSetting>(x => x.Id == DefaultId) ?? Repository.Save(new EventSetting());
        }    

    }
}