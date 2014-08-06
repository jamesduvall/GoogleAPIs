using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.Mirror.v1;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Google.Apis.Drive.v2;


namespace GoogleAPIs.Components
{
    public class AppFlowMetadata : FlowMetadata
    {
        private static IAuthorizationCodeFlow flow;

        public override string GetUserId(Controller controller)
        {
            // In this sample we use the session to store the user identifiers.
            // That's not the best practice, because you should have a logic to identify
            // a user. You might want to use "OpenID Connect".
            // You can read more about the protocol in the following link:
            // https://developers.google.com/accounts/docs/OAuth2Login.
            var user = controller.Session["user"];
            if (user == null)
            {
                user = Guid.NewGuid();
                controller.Session["user"] = user;
            }
            return user.ToString();
        }

        public override IAuthorizationCodeFlow Flow
        {
            get 
            {
                if(flow == null)
                {
                    using (var stream = new FileStream(System.Web.HttpContext.Current.Server.MapPath("~/client_secrets.json"), FileMode.Open, FileAccess.Read))
                    {
                        flow =
                            new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
                            {   
                                ClientSecrets = GoogleClientSecrets.Load(stream).Secrets,
                                Scopes = new[]
                                {
                                    Google.Apis.Oauth2.v2.Oauth2Service.Scope.UserinfoProfile,
                                    Google.Apis.Oauth2.v2.Oauth2Service.Scope.UserinfoEmail,
                                    YouTubeService.Scope.YoutubeReadonly,  // ExamplesController.YouTubeViewUploads
                                    MirrorService.Scope.GlassTimeline, MirrorService.Scope.GlassLocation,  // ExamplesController.MirrorTimeline
                                    DriveService.Scope.Drive // ExamplesController.JustDrive
                                },
                                DataStore = new FileDataStore("GoogleAPIs.Api.Auth.Store")
                            });
                    }
                }
                
                return flow; 
            }
        }
    }
}