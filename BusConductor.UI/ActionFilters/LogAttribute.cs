using System.Web;
using System.Web.Mvc;

namespace BusConductor.UI.ActionFilters
{
    public class LogAttribute : ActionFilterAttribute
    {
        //private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public LogAttribute()
        {
            Order = 1020;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
        //    Log.Info("Request received");

        //    Log.Info("User: " +
        //             (filterContext.HttpContext != null
        //              && filterContext.HttpContext.User != null
        //              && filterContext.HttpContext.User.Identity != null
        //                  ? filterContext.HttpContext.User.Identity.Name
        //                  : ""));

        //    Log.Info("URL: " +
        //             (filterContext.HttpContext != null
        //              && filterContext.HttpContext.Request != null
        //              && filterContext.HttpContext.Request.Url != null
        //                  ? filterContext.HttpContext.Request.Url.AbsolutePath
        //                  : ""));
            
        //    Log.Info("Data: " +
        //        (filterContext.HttpContext != null
        //        && filterContext.HttpContext.Request != null
        //        && filterContext.HttpContext.Request.Form != null
        //        ? HttpContext.Current.Server.UrlDecode(filterContext.HttpContext.Request.Form.ToString())
        //        : ""));
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if(filterContext.Exception != null)
            {
                //Log.Error(filterContext.Exception.Message, filterContext.Exception);
            }
        }
    }
}