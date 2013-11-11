using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusConductor.Data.Common;
using BusConductor.Data.Core;

namespace BusConductor.UI.IntegrationTests.Common
{
    public class GenericContextProvider : IContextProvider
    {
        private Context _context;

        public Context GetContext()
        {
            if(_context == null)
            {
                _context = new Context();
            }

            return _context;
        }

        //todo: transactions here and also in website?
        public void SaveChangesAndClearContext()
        {
            _context.SaveChanges();
            _context.Dispose();
            _context = null;
        }

        public void ClearContext()
        {
            _context.Dispose();
            _context = null;
        }
    }
}
