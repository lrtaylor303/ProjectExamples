using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ContactManager.Models;

namespace ContactManager.Controllers
{
    public class HomeController : Controller
    {

        private IContactUnitOfWork unitOfWork { get; set; }

        public HomeController(IContactUnitOfWork unit)
        {
            unitOfWork = unit;
        }

        public IActionResult Index()
        {
            var queryOptions = new QueryOptions<Contact>
            {
                Includes = "Category",
                OrderBy = _ => _.Firstname
            };
            return View(unitOfWork.Contacts.List(queryOptions));
            
        }

    }
}
