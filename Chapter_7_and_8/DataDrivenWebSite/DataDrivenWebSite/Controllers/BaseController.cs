using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;

namespace DataDrivenWebSite.Controllers
{
    public class BaseController : Controller
    {
        private readonly IServiceLocator serviceLocator;

        public BaseController(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        protected T Using<T>() where T : class
        {
            var handler = serviceLocator.GetInstance<T>();
            if (handler == null)
            {
                throw new NullReferenceException("Unable to resolve type with service locator; type " + typeof(T).Name);
            }
            return handler;
        }
    }
}
