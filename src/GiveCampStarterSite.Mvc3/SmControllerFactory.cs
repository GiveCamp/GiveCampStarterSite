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
            if (controllerType == null) return base.GetControllerInstance(requestContext, controllerType);

            try
            {
                return ObjectFactory.GetInstance(controllerType) as Controller;
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine(ObjectFactory.WhatDoIHave());
                throw;
            }
        }
    }
}