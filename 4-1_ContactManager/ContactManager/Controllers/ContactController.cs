using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactManager.Models;

namespace ContactManager.Controllers
{
    public class ContactController : Controller
    {
        private IContactUnitOfWork unitOfWork { get; set; }
        public ContactController(IContactUnitOfWork unit)
        {
            unitOfWork = unit;
        }

        public IActionResult Details(int id)
        {
            var queryOptions = new QueryOptions<Contact>
            {
                Includes = "Category",
                OrderBy = _ => _.ContactId,
                Where = _ => _.ContactId == id
            };

            return View(unitOfWork.Contacts.List(queryOptions).FirstOrDefault());
            
        }

        [HttpGet]
        public IActionResult Add()
        {
            var queryOptions = new QueryOptions<Category>
            {
                OrderBy = _ => _.Name
            };
            ViewBag.Action = "Add";
            ViewBag.Categories = unitOfWork.Categories.List(queryOptions);
            return View("Edit", new Contact());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var categoryQueryOptions = new QueryOptions<Category>
            {
                OrderBy = _ => _.Name
            };
            ViewBag.Action = "Edit";
            ViewBag.Categories = unitOfWork.Categories.List(categoryQueryOptions);

            var contactQueryOptions = new QueryOptions<Contact>
            {
                Includes = "Category",
                OrderBy = _ => _.ContactId,
                Where = _ => _.ContactId == id
            };
            return View(unitOfWork.Contacts.List(contactQueryOptions).FirstOrDefault());
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            string action = (contact.ContactId == 0) ? "Add" : "Edit";

            var queryOptions = new QueryOptions<Category>
            {
                OrderBy = _ => _.Name
            };

            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                    contact.DateAdded = DateTime.Now;
                    unitOfWork.Contacts.Insert(contact);
                }         
                else
                {
                    unitOfWork.Contacts.Update(contact);
                }  
                unitOfWork.Save();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = action;
                ViewBag.Categories = unitOfWork.Categories.List(queryOptions);
                return View(contact);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contactQueryOptions = new QueryOptions<Contact>
            {
                Includes = "Category",
                OrderBy = _ => _.ContactId,
                Where = _ => _.ContactId == id
            };
            return View(unitOfWork.Contacts.List(contactQueryOptions).FirstOrDefault());
        }

        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            unitOfWork.Contacts.Delete(contact);
            unitOfWork.Save();
            return RedirectToAction("Index", "Home");
        }
    }
}
