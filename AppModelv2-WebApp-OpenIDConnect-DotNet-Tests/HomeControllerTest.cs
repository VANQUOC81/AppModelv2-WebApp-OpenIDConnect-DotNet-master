using AppModelv2_WebApp_OpenIDConnect_DotNet.Controllers;
using Microsoft.Owin.Security;
using Microsoft.Owin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web;
using System.IO;

namespace AppModelv2_WebApp_OpenIDConnect_DotNet_Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index_ReturnsView()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetUser_ReturnsIdentity()
        {
            // Arrange
            var controller = new HomeController();

            var httpRequest = new HttpRequest("/", "http://example.com", "");
            var stringWriter = new StringWriter();
            var httpResponse = new HttpResponse(stringWriter);
            var httpContext = new HttpContext(httpRequest, httpResponse);
            var httpContextBase = new HttpContextWrapper(httpContext);

            controller.ControllerContext = new ControllerContext
            {
                Controller = controller,
                HttpContext = httpContextBase
            };

            //controller.HttpContext = context.Object;
            //controller.HttpContext.GetOwinContext = () => owinContext.Object;

            // Act
            controller.GetUser();

            // Assert
            //authenticationManager.Verify(x => x.SignOut(
                //OpenIdConnectAuthenticationDefaults.AuthenticationType,
                //CookieAuthenticationDefaults.AuthenticationType), Times.Once);
        }
    }
}
