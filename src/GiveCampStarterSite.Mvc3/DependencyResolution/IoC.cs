using StructureMap;
namespace GiveCampStarterSite {
    using GiveCampStarterSite.Controllers;
    using GiveCampStarterSite.Data;

    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
                            
                            x.For<IRepository>().Use<EntityFrameworkRepository>();
                        });
            return ObjectFactory.Container;
        }
    }
}