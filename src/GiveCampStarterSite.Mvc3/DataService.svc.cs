using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;

namespace GiveCampStarterSite
{
    using GiveCampStarterSite.Models;

    public class DataService : DataService<GiveCampEntities>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("Charities", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("CharityProjects", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("Sponsors", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("Pages", EntitySetRights.AllRead);
            
            // config.SetServiceOperationAccessRule("MyServiceOperation", ServiceOperationRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
        }
    }
}
