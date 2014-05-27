using System.Security.Principal;

namespace MobileBookStore.DataContracts
{
    public interface IPrincipalAccessor
    {
        /// <summary>
        /// Gets the current principal.
        /// </summary>
        /// <returns></returns>
        IPrincipal GetCurrentPrincipal();       
    }
}
