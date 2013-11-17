using System.Web;

namespace BusConductor.UI.Misc
{
    public class VirtualPathUtilityWrapper : IVirtualPathUtilityWrapper
    {
        public string ToAbsolute(string virtualPath)
        {
            return VirtualPathUtility.ToAbsolute(virtualPath);
        }
    }
}