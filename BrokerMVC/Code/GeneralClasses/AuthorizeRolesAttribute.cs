using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BrokerMVC
{
    public class AuthorizeRolesAttribute: AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params Roles[] roles) : base()
        {
            Roles = string.Join(",", roles);
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var httpContext = filterContext.HttpContext;
            var request = httpContext.Request;
            var response = httpContext.Response;
            var user = httpContext.User;
            if (!request.IsAjaxRequest())
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
            else {
                if (user.Identity.IsAuthenticated == false)
                {
                    response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    base.HandleUnauthorizedRequest(filterContext);
                }
                else
                    response.StatusCode = (int)HttpStatusCode.Accepted;
                //response.SuppressFormsAuthenticationRedirect = true;
                //response.End();
            }
            
        }
    }
    public class AjaxAuthorize : AuthorizeRolesAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var httpContext = filterContext.HttpContext;
            var request = httpContext.Request;
            var response = httpContext.Response;
            var user = httpContext.User;
            if (request.IsAjaxRequest())
            {
                if (user.Identity.IsAuthenticated == false)
                    response.StatusCode = (int)HttpStatusCode.Unauthorized;
                else
                    response.StatusCode = (int)HttpStatusCode.Accepted;
                response.SuppressFormsAuthenticationRedirect = true;
                response.End();
            }
            base.HandleUnauthorizedRequest(filterContext);
        }
    }
}