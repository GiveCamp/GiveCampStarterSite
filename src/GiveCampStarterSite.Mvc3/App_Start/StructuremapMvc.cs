using System.Web.Mvc;

[assembly: WebActivator.PreApplicationStartMethod(typeof(GiveCampStarterSite.App_Start.StructuremapMvc), "Start")]

namespace GiveCampStarterSite.App_Start {
    public static class StructuremapMvc {
        public static void Start() {
            var container = IoC.Initialize();
            DependencyResolver.SetResolver(new SmDependencyResolver(container));
        }
    }
}