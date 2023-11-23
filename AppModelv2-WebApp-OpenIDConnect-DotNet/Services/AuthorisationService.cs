using AppModelv2_WebApp_OpenIDConnect_DotNet.Services.Interfaces;
using System.Security.Principal;
using System.Web;

namespace AppModelv2_WebApp_OpenIDConnect_DotNet.Services
{
    public class AuthorisationService : IAuthorisationService
    {
        public AuthorisationService()
        {

        }

        public IPrincipal GetPrincipal(HttpContextBase httpContextBase)
        {
            bool result = IsAuthenticated(httpContextBase);

            if (result)
            {
                return (IPrincipal)httpContextBase.GetOwinContext().Authentication.User.Identity;
            }
            else
            {
                return null;
            }
        }

        public bool IsAuthenticated(HttpContextBase httpContextBase)
        {
            var owinContext = httpContextBase.GetOwinContext();
            var authentication = owinContext.Authentication;
            var user = authentication.User.Identity;

            return user.IsAuthenticated;
        }
    }
}
