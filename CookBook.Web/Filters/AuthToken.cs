using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CookBook.Web.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthToken : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.Items["User"];
            if (user == null)
            {
                context.Result = new JsonResult(
                    new
                    {
                        message = "Unauthorized"
                    })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
        }
    }
}
