using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using TenderPlus.Core.Models;

namespace TenderPlus.Api.Authorize
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (LoginCore)context.HttpContext.Items["User"];
            string authorizationFlag = ConfigValueProvider.Get("Auth");
            if (authorizationFlag.ToUpper() == "TRUE")
            {
                if (user == null)
                {
                    context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                }
            }
        }

    }
}
