using System.Web;
using System.Web.Mvc;
using BusConductor.Data.Common;
using BusConductor.Data.Core;
using StructureMap.Attributes;

namespace BusConductor.UI.ActionFilters
{
    public class EntityFrameworkWriteContextAttribute : ActionFilterAttribute
    {
        [SetterProperty]
        public IContextProvider ContextProvider { get; set; }

        public EntityFrameworkWriteContextAttribute()
        {
            Order = 1000;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            ContextProvider.SaveChanges();
            ContextProvider.Dispose();
        }
    }
}