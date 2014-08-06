using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Oauth2.v2;
using Google.Apis.Services;
using GoogleAPIs.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GoogleAPIs.Controllers
{
    public class HomeController : BaseExamplesController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Slides()
        {
            return View();
        }

        public async Task<ActionResult> Login(CancellationToken cancellationToken)
        {
            var result = await new AuthorizationCodeMvcApp(this, new AppFlowMetadata()).AuthorizeAsync(cancellationToken);

            if (result.Credential != null)
            {
                var service = new Oauth2Service(new BaseClientService.Initializer
                {
                    HttpClientInitializer = result.Credential,
                    ApplicationName = this.ApplicationName
                });

                var response = await service.Userinfo.Get().ExecuteAsync();

                this.Session["UserInfo"] = response;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return new RedirectResult(result.RedirectUri);
            }
        }

        public ActionResult Logout()
        {
            this.Session["user"] = null;

            this.Session["UserInfo"] = null;

            return RedirectToAction("Index", "Home");
        }
    }
}