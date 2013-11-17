using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusConductor.UI.Misc
{
    public interface IVirtualPathUtilityWrapper
    {
        string ToAbsolute(string virtualPath);
    }
}