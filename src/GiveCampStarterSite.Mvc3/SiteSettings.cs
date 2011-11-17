namespace GiveCampStarterSite
{
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
            return Repository.Get<EventSetting>(DefaultId) ?? Repository.Save(new EventSetting());
        }    
    }
}