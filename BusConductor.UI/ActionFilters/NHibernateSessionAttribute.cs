using System.Web.Mvc;
using NHibernate.Context;

namespace BusConductor.UI.ActionFilters
{
    /// <remarks>
    /// This project template uses the 'Session per controller action' pattern, rather than the usual 'session per request' pattern.
    /// This is because when we use NServiceBus, we need to wrap the session and transaction in a TransactionScope.
    /// 
    /// Based on code in NHibernate 3.0 Cookbook.
    /// </remarks>
    public class NHibernateSessionAttribute : ActionFilterAttribute
    {
        public NHibernateSessionAttribute()
        {
            Order = 1000;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = MvcApplication.SessionFactory.OpenSession();
            CurrentSessionContext.Bind(session);
            session.BeginTransaction();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = CurrentSessionContext.Unbind(MvcApplication.SessionFactory);

            if (session != null)
            {
                if (session.Transaction != null && session.Transaction.IsActive)
                {
                    if (filterContext.Exception == null)
                    {
                        session.Transaction.Commit();
                    }
                    else
                    {
                        //Todo: May need error handling, logging and maybe rolling back. It is important we unbind the session.
                        session.Transaction.Rollback();
                    }
                }

                if(session.IsOpen)
                {
                    session.Close();
                }
            }   
        }
    }
}