using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusConductor.Data.Core;

namespace BusConductor.Data.Common
{
    public class GenericContextProvider : IContextProvider
    {
        private Context _context;

        public Context GetContext()
        {
            return _context ?? (_context = new Context());
        }

        public void SaveChanges()
        {
            //todo: maybe change?
            GetContext().SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~GenericContextProvider() 
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) 
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
