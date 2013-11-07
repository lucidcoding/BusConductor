using BusConductor.Data.Core;

namespace BusConductor.Data.Common
{
    public interface IContextProvider
    {
        Context GetContext();
    }
}
