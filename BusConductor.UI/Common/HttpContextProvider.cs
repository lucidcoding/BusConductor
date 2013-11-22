using System;
using System.Web;
using BusConductor.Data.Common;
using BusConductor.Data.Core;

namespace BusConductor.UI.Common
{   
    public class HttpContextProvider : IContextProvider
    {
        public Context GetContext()
        {
            if(HttpContext.Current.Items["Context"] == null)
            {
                throw new Exception("Context has not been set.");
            }

            return HttpContext.Current.Items["Context"] as Context;
        }

        public void Dispose()
        {

        }


        public void SaveChanges()
        {
        }
    }
}
