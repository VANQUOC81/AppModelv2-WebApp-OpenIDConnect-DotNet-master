using System.Security.Principal;
using System.Web;

namespace AppModelv2_WebApp_OpenIDConnect_DotNet.Services.Interfaces
{
    public interface IAuthorisationService
    {
        bool IsAuthenticated(HttpContextBase httpContextBase);

        IPrincipal GetPrincipal(HttpContextBase httpContextBase);
    }
}
