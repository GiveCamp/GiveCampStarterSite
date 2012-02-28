namespace GiveCampStarterSite
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;

    using StructureMap;

    public class SmControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            IController controllerObject = null;
            
            if (controllerType != null)
                controllerObject = ObjectFactory.GetInstance(controllerType) as Controller;
            
            return controllerObject;
        }
    }
}