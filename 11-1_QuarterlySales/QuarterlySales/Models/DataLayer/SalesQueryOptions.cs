
namespace QuarterlySales.Models
{
    public class SalesQueryOptions : QueryOptions<Sales>
    {
        public void SortFilter(SalesGridBuilder build)
        {
            if (build.IsFilterByYear)
            {
                Where = _ => _.Year.ToString() == build.CurrentRoute.YearFilter;
            }

            if (build.IsFilterByQuarter)
            {
                Where = _ => _.Quarter.ToString() == build.CurrentRoute.QuarterFilter;
            }

            if (build.IsFilterByEmployee)
            {
                Where = _ => _.Employee.EmployeeId.ToString() == build.CurrentRoute.EmployeeFilter;
            }
            
            if (build.IsFilterByAmount)
            {
                Where = _ => _.Amount.ToString() == build.CurrentRoute.AmountFilter;
            }






            if (build.IsSortByEmployee)
            {
                OrderBy = _ => _.Employee;
            }
            else if (build.IsSortByQuarter)
            {
                OrderBy = _ => _.Quarter;
            }
            else if (build.IsSortByAmount)
            {
                OrderBy = _ => _.Amount;
            }
            else
            {
                OrderBy = _ => _.Year;
            }
        }
    }
}
