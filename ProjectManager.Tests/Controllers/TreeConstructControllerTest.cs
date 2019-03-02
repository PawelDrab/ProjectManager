using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using ProjectManager;
using ProjectManager.Controllers;
using ProjectManager.Models;

namespace ProjectManager.Tests.Controllers
{
    class TreeConstructControllerTest
    {

        [Test]
        public void TreeConstructListView()
        {
            // Arrange
            TreeConstructorController controller = new TreeConstructorController();

            // Act
            ViewResult result = controller.TreeConstructorListView("level_asc", null, null, 1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        public void TreeConstructAddView(int MasterID, int Level)
        {
            // Arrange
            TreeConstructorController controller = new TreeConstructorController();

            // Act
            ViewResult result = controller.TreeConstructorAddView(MasterID, Level) as ViewResult;

            // Assert
            Assert.AreEqual("TreeConstructorAddView", result.ViewBag.Title);
        }

        [TestCase(1000, 1)]
        public void TreeConstructAddView_AddForNotExistingMasterID(int MasterID, int Level)
        {
            // Arrange
            TreeConstructorController controller = new TreeConstructorController();

            // Act
            ViewResult result = controller.TreeConstructorAddView(MasterID, Level) as ViewResult;

            // Assert
            Assert.AreSame(typeof(HttpNotFoundResult), result);
        }



    }
}
