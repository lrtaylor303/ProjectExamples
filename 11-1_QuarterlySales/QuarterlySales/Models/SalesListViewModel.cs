using System.Collections.Generic;

namespace QuarterlySales.Models
{
    public class SalesListViewModel
    {
        public IEnumerable<Sales> Sales { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }
    }
}
