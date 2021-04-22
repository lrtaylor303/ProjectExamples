using ContactManager.Controllers;
using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ContactManager.Text
{
    public class ContactControllerTest
    {
        [Fact]
        public void DetailsMethod_CallsToWContactsOnlyOnce()
        {
            var unitOfWorkMock = new Mock<IContactUnitOfWork>();
            var contactsRepo = new Mock<IRepository<Contact>>();
            var categoriesRepo = new Mock<IRepository<Category>>();
            unitOfWorkMock.Setup(_ => _.Contacts).Returns(contactsRepo.Object);
            unitOfWorkMock.Setup(_ => _.Categories).Returns(categoriesRepo.Object);

            var uut = new ContactController(unitOfWorkMock.Object);

            var retVal = uut.Details(0);

            unitOfWorkMock.Verify(_ => _.Contacts.List(It.IsAny<QueryOptions<Contact>>()), Times.Once());
        }

        [Fact]
        public void AddMethod_CallsToCategoriesOnlyOnce()
        {
            var unitOfWorkMock = new Mock<IContactUnitOfWork>();
            var contactsRepo = new Mock<IRepository<Contact>>();
            var categoriesRepo = new Mock<IRepository<Category>>();
            unitOfWorkMock.Setup(_ => _.Contacts).Returns(contactsRepo.Object);
            unitOfWorkMock.Setup(_ => _.Categories).Returns(categoriesRepo.Object);

            var uut = new ContactController(unitOfWorkMock.Object);

            var retVal = uut.Add();

            unitOfWorkMock.Verify(_ => _.Categories.List(It.IsAny<QueryOptions<Category>>()), Times.Once());
        }

        [Fact]
        public void EditMethod_CallsToContactsOnlyOnce()
        {
            var unitOfWorkMock = new Mock<IContactUnitOfWork>();
            var contactsRepo = new Mock<IRepository<Contact>>();
            var categoriesRepo = new Mock<IRepository<Category>>();
            unitOfWorkMock.Setup(_ => _.Contacts).Returns(contactsRepo.Object);
            unitOfWorkMock.Setup(_ => _.Categories).Returns(categoriesRepo.Object);

            var uut = new ContactController(unitOfWorkMock.Object);

            var retVal = uut.Edit(0);

            unitOfWorkMock.Verify(_ => _.Contacts.List(It.IsAny<QueryOptions<Contact>>()), Times.Once());

        }

        [Fact]
        public void EditMethod_CallsToCategoriesOnlyOnce()
        {
            var unitOfWorkMock = new Mock<IContactUnitOfWork>();
            var contactsRepo = new Mock<IRepository<Contact>>();
            var categoriesRepo = new Mock<IRepository<Category>>();
            unitOfWorkMock.Setup(_ => _.Contacts).Returns(contactsRepo.Object);
            unitOfWorkMock.Setup(_ => _.Categories).Returns(categoriesRepo.Object);

            var uut = new ContactController(unitOfWorkMock.Object);

            var retVal = uut.Edit(0);

            unitOfWorkMock.Verify(_ => _.Categories.List(It.IsAny<QueryOptions<Category>>()), Times.Once());

        }

        [Fact]
        public void EditMethod_CallsToContactsAdd()
        {
            var unitOfWorkMock = new Mock<IContactUnitOfWork>();
            var contactsRepo = new Mock<IRepository<Contact>>();
            var categoriesRepo = new Mock<IRepository<Category>>();
            unitOfWorkMock.Setup(_ => _.Contacts).Returns(contactsRepo.Object);
            unitOfWorkMock.Setup(_ => _.Categories).Returns(categoriesRepo.Object);

            var uut = new ContactController(unitOfWorkMock.Object);

            var retVal = uut.Edit(new Contact());

            unitOfWorkMock.Verify(_ => _.Contacts.Insert(It.IsAny<Contact>()), Times.Once());

        }

        [Fact]
        public void EditMethod_CallsToContactsEdit()
        {
            var unitOfWorkMock = new Mock<IContactUnitOfWork>();
            var contactsRepo = new Mock<IRepository<Contact>>();
            var categoriesRepo = new Mock<IRepository<Category>>();
            unitOfWorkMock.Setup(_ => _.Contacts).Returns(contactsRepo.Object);
            unitOfWorkMock.Setup(_ => _.Categories).Returns(categoriesRepo.Object);

            var uut = new ContactController(unitOfWorkMock.Object);

            var retVal = uut.Edit(new Contact() { ContactId = 1 });

            unitOfWorkMock.Verify(_ => _.Contacts.Update(It.IsAny<Contact>()), Times.Once());

        }

        [Fact]
        public void DeleteMethod_CallsToDelete()
        {
            var unitOfWorkMock = new Mock<IContactUnitOfWork>();
            var contactsRepo = new Mock<IRepository<Contact>>();
            var categoriesRepo = new Mock<IRepository<Category>>();
            unitOfWorkMock.Setup(_ => _.Contacts).Returns(contactsRepo.Object);
            unitOfWorkMock.Setup(_ => _.Categories).Returns(categoriesRepo.Object);

            var uut = new ContactController(unitOfWorkMock.Object);

            var retVal = uut.Delete(new Contact() { ContactId = 1 });

            unitOfWorkMock.Verify(_ => _.Contacts.Delete(It.IsAny<Contact>()), Times.Once());

        }

        [Fact]
        public void DeleteMethod_CallsToDeleteContact()
        {
            var unitOfWorkMock = new Mock<IContactUnitOfWork>();
            var contactsRepo = new Mock<IRepository<Contact>>();
            var categoriesRepo = new Mock<IRepository<Category>>();
            unitOfWorkMock.Setup(_ => _.Contacts).Returns(contactsRepo.Object);
            unitOfWorkMock.Setup(_ => _.Categories).Returns(categoriesRepo.Object);

            var uut = new ContactController(unitOfWorkMock.Object);

            var retVal = uut.Delete(new Contact() { ContactId = 2});

            unitOfWorkMock.Verify(_ => _.Contacts.Delete(It.IsAny<Contact>()), Times.Once());

        }
    }
}
