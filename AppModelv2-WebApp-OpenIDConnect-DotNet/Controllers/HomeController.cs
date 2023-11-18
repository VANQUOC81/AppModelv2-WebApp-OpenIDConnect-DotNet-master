using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using AppModelv2_WebApp_OpenIDConnect_DotNet.Services;
using AppModelv2_WebApp_OpenIDConnect_DotNet.Services.Interfaces;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;

namespace AppModelv2_WebApp_OpenIDConnect_DotNet.Controllers
{
    public class HomeController : Controller
    {
        private IAuthorisationService _authorisationService;

        public HomeController()
        {
            _authorisationService = new AuthorisationService();
        }
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Send an OpenID Connect sign-in request.
        /// Alternatively, you can just decorate the SignIn method with the [Authorize] attribute
        /// </summary>
        [Authorize]
        public ActionResult SignIn()
        //public void SignIn()

        {
            /*if (!Request.IsAuthenticated)
            {
                HttpContext.GetOwinContext().Authentication.Challenge(
                    new AuthenticationProperties { RedirectUri = "/AppModelv2-WebApp-OpenIDConnect-DotNet/" }, // "/" is localhost, redirect after success authentication
                    OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }*/

            //var user = HttpContext.User.Identity;
            return Redirect("/AppModelv2-WebApp-OpenIDConnect-DotNet/");
            // if View() then SignIn.cshtml should exists.
            //return View();
        }

        /// <summary>
        /// Send an OpenID Connect sign-out request.
        /// </summary>
        public void SignOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(
                    OpenIdConnectAuthenticationDefaults.AuthenticationType,
                    CookieAuthenticationDefaults.AuthenticationType);
        }

        /// <summary>
        /// Get Identity User
        /// </summary>
        public IIdentity GetUser()
        {
            _authorisationService.IsAuthenticated(HttpContext);
            var owinContext = HttpContext.GetOwinContext();
            var authentication = owinContext.Authentication;
            var user = authentication.User.Identity;
            return user;
        }
    }
}
