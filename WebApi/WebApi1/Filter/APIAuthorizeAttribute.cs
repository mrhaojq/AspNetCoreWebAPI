using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Net.Http.Headers;
using System.Text;
using System.Security.Principal;

namespace WebApi1.Filter
{
    public class APIAuthorizeAttribute:AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //base.OnAuthorization(actionContext);
            //如果用户使用了forms authentication,就不比再做basic authentication了
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                return;
            }

            var authHeader = actionContext.Request.Headers.Authorization;

            if (authHeader != null)
            {
                if (authHeader.Scheme.Equals("basic",StringComparison.OrdinalIgnoreCase)
                    &&!string.IsNullOrWhiteSpace(authHeader.Parameter))
                {
                    var credArray = GetCredentials(authHeader);

                    var userName = credArray[0];
                    var key = credArray[1];
                    var ip = System.Web.HttpContext.Current.Request.UserHostAddress;


                    if (IsResourceOwner(userName,actionContext))
                    {
                        //you can use Websecurity or asp.net membership provider to login,for
                        //he sake of keeping example simple,we used out own login functionality

                        //if (APIAuthorizeInfoValidate.ValidateApi(userName,key,ip))
                        if(true)
                        {
                            //这里可以自定义权限验证方法
                            var currentPrincipal = new GenericPrincipal(new GenericIdentity(userName), null);
                            Thread.CurrentPrincipal = currentPrincipal;
                            return;
                        }
                    }
                }
            }

            HandleUnauthorizedRequest(actionContext);
        }

        private string[] GetCredentials(AuthenticationHeaderValue authHeader)
        {
            //base 64 encoded string
            var rawCred = authHeader.Parameter;
            var encoding = Encoding.GetEncoding("iso-8859-1");
            var cred = encoding.GetString(Convert.FromBase64String(rawCred));

            var credArray = cred.Split(':');
            return credArray;
        }

        private bool IsResourceOwner(string userName, HttpActionContext actionContext)
        {
            var routeData = actionContext.Request.GetRouteData();
            var resourceUserName = routeData.Values["userName"] as string;

            if (resourceUserName==userName)
            {
                return true;
            }

            return false;
        }

        private void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            actionContext.Request.Headers.Add("WWW-Authenticate","Basic Scheme='elearning' localtion='http://localhost:8323/APITest'");
        }
    }
}