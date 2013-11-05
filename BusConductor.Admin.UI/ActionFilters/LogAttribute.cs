using System.Web.Mvc;

namespace BusConductor.Admin.UI.ActionFilters
{
    public class LogAttribute : ActionFilterAttribute
    {
        public LogAttribute()
        {
            Order = 1020;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if(filterContext.Exception != null)
            {
            }
        }
    }
}