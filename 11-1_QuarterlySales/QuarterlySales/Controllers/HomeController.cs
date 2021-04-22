using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuarterlySales.Models;

namespace QuarterlySales.Controllers
{
    public class HomeController : Controller
    {
        private SalesUnitOfWork context { get; set; }
        public HomeController(SalesContext ctx) => context = new SalesUnitOfWork(ctx);

        [HttpGet]
        public ViewResult Index(SalesGridDTO values)
        {
            var build = new SalesGridBuilder(HttpContext.Session, values,
                defaultSortField: nameof(Sales.Year));

            var data = new SalesQueryOptions
            {
                OrderByDirection = build.CurrentRoute.SortDirection,
                PageNumber = build.CurrentRoute.PageNumber,
                PageSize = build.CurrentRoute.PageSize
            };

            data.SortFilter(build);
            var sales = context.Sales.List(data);
            var vm = new SalesListViewModel
            {
                Sales = sales.Skip((build.CurrentRoute.PageNumber -1) * build.CurrentRoute.PageSize).Take(build.CurrentRoute.PageSize),
                Employees = context.Employee.List(new QueryOptions<Employee>
                {
                    OrderBy = _ => _.EmployeeId
                }),
                CurrentRoute = build.CurrentRoute,
                TotalPages = build.GetTotalPages(sales.Count())
            };

            return View(vm);

        }

        [HttpPost]
        public RedirectToActionResult Filter(string[] filter, bool clear = false)
        {
            var build = new SalesGridBuilder(HttpContext.Session);
            if (clear)
            {
                build.ClearFilterSegments();
            } else
            {
                build.CurrentRoute.PageNumber = 1;
                build.LoadFilterSegments(filter);
            }

            build.SaveRouteSegments();
            return RedirectToAction("Index", build.CurrentRoute);
        }

    }
}
