using binbash.Results;
using binbash.Services;
using Microsoft.AspNet.Identity;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace binbash.Filters {

    public class ValidateIsAdmin : ActionFilterAttribute {

        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            if(!HttpContext.Current.User.Identity.IsAuthenticated) {
                filterContext.Result = new HttpUnauthorizedResult();
                return;
            }

            string userId = HttpContext.Current.User.Identity.GetUserId();

            if(!AuthService.UserIsAdmin(userId)) {
                filterContext.Result = new HttpForbiddenResult();
            } else {
                base.OnActionExecuting(filterContext);
            }
        }
    }
}