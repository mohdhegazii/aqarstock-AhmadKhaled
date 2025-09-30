using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BrokerMVC;
using BrokerMVC.Controllers;
using BrokerMVC.Models;
using BrokerMVC.Models.ViewModel;

namespace BrokerMVC.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GeSpecialtProperties_ShouldReturnFirstPage_WhenPageIsNull()
        {
            // Arrange
            HomeController controller = new HomeController();
            int pageSize = 5;

            // Act
            PartialViewResult result = controller.GeSpecialtProperties(null, pageSize) as PartialViewResult;
            var model = result.Model as HorizonatlPropertyListView;

            // Assert
            Assert.IsNotNull(result, "Result should not be null.");
            Assert.IsNotNull(model, "Model should not be null.");
            Assert.IsTrue(model.ReqularProperties.Count > 0, "The first page of properties should be returned, but the list is empty.");
        }

        [TestMethod]
        public void GetPropertiesBySaleType_ShouldReturnFirstPageOfResults()
        {
            // Arrange
            var controller = new HomeController();
            int saleTypeId = 1; // Assuming 1 is for Sale
            int pageSize = 5;

            // Act
            var result = controller.GetPropertiesBySaleType(saleTypeId, 1, pageSize) as PartialViewResult;
            var model = result.Model as HorizonatlPropertyListView;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(model);
            // This assertion is expected to fail with the buggy code if there are fewer than 11 properties of the given sale type.
            // The bug causes page 1 to skip 10 items. After the fix, it will skip 0 items and return the first page.
            Assert.IsTrue(model.ReqularProperties.Count > 0, "The first page of properties should be returned, but the list is empty. This is likely due to the pagination bug skipping too many records.");
        }
    }
}
