namespace GiveCampStarterSite.Services
{
    using System;

    using GiveCampStarterSite.ServiceContracts;

    public class MessageService : IMessageService
    {
        public string HomePageMessage
        {
            get
            {
                return "Welcome to ASP.NET MVC!";
            }
        }
    }
}