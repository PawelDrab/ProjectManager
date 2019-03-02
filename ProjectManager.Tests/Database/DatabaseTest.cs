using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using ProjectManager;
using ProjectManager.Controllers;
using ProjectManager.Models;

namespace ProjectManager.Tests.Database
{
    class DatabaseTest
    {


        [Test]
        public void AddTreeConstruct_InvokeMock_NodeAdded()
        {
            // Arrange
            var treeConstructContextMock = new Mock<ITreeConstructorController>();

            var newNode = new TreeConstructorModel();
            newNode.ItemName = "Test item";
            newNode.AutoCreate = true;
            newNode.IsBranch = false;
            newNode.ItemDescription = "Item descriprion";
            newNode.Level = 0;
            newNode.MasterItemID = 0;


            //treeConstructContextMock.Setup(x => x.GetTreeConstruct());
            //treeConstructContextMock.Setup(x => x.TreeConstruct.Add(It.IsAny<TreeConstructorModel>())).Returns((TreeConstructorModel t) => t);

            treeConstructContextMock.Setup(x => x.Add(newNode));

            // Assert
            Assert.AreEqual(newNode.ItemName, "Test item");
            Assert.AreEqual(newNode.AutoCreate, true);
            Assert.AreEqual(newNode.IsBranch, false);
            Assert.AreEqual(newNode.ItemDescription, "Item descriprion");
            Assert.AreEqual(newNode.Level, 0);
            Assert.AreEqual(newNode.MasterItemID, 0);

            treeConstructContextMock.Verify(x => x.Add(newNode), Times.Once);
        }

        [Test]
        public void EditTreeConstruct_NodeEdited()
        {
            // Arrange
            var treeConstructContextMock = new Mock<ApplicationDbContext>();
            treeConstructContextMock.Setup(x => x.TreeConstruct.Find(1));

        }

    }
}
