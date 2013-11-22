using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusConductor.Data.Core;

namespace BusConductor.Data.Common
{
    public class StubContextProvider : IContextProvider
    {
        public Context GetContext()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            
        }


        public void SaveChanges()
        {
        }
    }
}
