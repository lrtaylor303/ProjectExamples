using ContactManager.Controllers;
using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace ContactManager.Text
{
    public class HomeControllerTest
    {
        [Fact]
        public void GivenACallToHomeControllerIndex_WhenThisAction_ThenThisResult()
        {
            var unitOfWorkMock = new Mock<IContactUnitOfWork>();
            var contactsRepo = new Mock<IRepository<Contact>>();
            var categoriesRepo = new Mock<IRepository<Category>>();
            unitOfWorkMock.Setup(_ => _.Contacts).Returns(contactsRepo.Object);
            unitOfWorkMock.Setup(_ => _.Categories).Returns(categoriesRepo.Object);

            var uut = new HomeController(unitOfWorkMock.Object);

            var retVal = uut.Index();

            Assert.IsType<ViewResult>(retVal);
        }

    }
}
