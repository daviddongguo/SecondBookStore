using David.SecondBook.OnlineStore.Domain.Entities;
using David.SecondBook.OnlineStore.WebApp.Infrastructure.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace David.SecondBook.OnlineStore.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            IocConfig.Register();
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}
