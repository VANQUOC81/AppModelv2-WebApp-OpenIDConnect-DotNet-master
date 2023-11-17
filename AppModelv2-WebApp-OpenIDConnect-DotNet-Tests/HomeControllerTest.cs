using AppModelv2_WebApp_OpenIDConnect_DotNet.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

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
    }
}
