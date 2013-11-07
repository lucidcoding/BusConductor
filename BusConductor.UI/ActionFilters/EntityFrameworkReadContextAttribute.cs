using System.Web;
using System.Web.Mvc;
using BusConductor.Data.Core;

namespace BusConductor.UI.ActionFilters
{
    public class EntityFrameworkReadContextAttribute : ActionFilterAttribute
    {
        public EntityFrameworkReadContextAttribute()
        {
            Order = 1000;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var context = new Context();
            HttpContext.Current.Items["Context"] = context;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var context = HttpContext.Current.Items["Context"] as Context;
            context.Dispose();
            HttpContext.Current.Items["Context"] = null;
        }
    }
}