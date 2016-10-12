using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelManagementWebAPI;
using HotelManagementWebAPI.Controllers;

namespace HotelManagementWebAPI.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            WelcomeController controller = new WelcomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
