using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoogleAPIs.Controllers
{
    public class BaseExamplesController : Controller
    {
        protected string ApiKey
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["ApiKey"];
            }
        }

        protected string ApplicationName
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["ApplicationName"];
            }
        }
    }
}