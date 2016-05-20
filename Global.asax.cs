using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace mi9
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DisableDeafultJsonbinder();
            ModelBinders.Binders.DefaultBinder = new JsonModelBinder();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private void DisableDeafultJsonbinder()
        {
            var defaultJsonModelBinder = ValueProviderFactories.Factories.OfType<JsonValueProviderFactory>().First();
            ValueProviderFactories.Factories.Remove(defaultJsonModelBinder);
        }
       
    }
}