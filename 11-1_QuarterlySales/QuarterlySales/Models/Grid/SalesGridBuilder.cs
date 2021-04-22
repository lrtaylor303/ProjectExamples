using Microsoft.AspNetCore.Http;


namespace QuarterlySales.Models
{
    public class SalesGridBuilder : GridBuilder
    {
        public SalesGridBuilder(ISession session) : base(session) { }

        public SalesGridBuilder(ISession session, SalesGridDTO values,
            string defaultSortField) : base(session, values, defaultSortField)
        {
            bool isInitial = values.Year.IndexOf(FilterPrefix.Year) == -1;
            routes.YearFilter = (isInitial) ? FilterPrefix.Year + values.Year : values.Year;
            routes.QuarterFilter = (isInitial) ? FilterPrefix.Quarter + values.Quarter : values.Quarter;
            routes.EmployeeFilter = (isInitial) ? FilterPrefix.Employee + values.Employee : values.Employee;
            routes.AmountFilter = (isInitial) ? FilterPrefix.Amount + values.Amount : values.Amount;

            SaveRouteSegments();
        }

        public void LoadFilterSegments(string[] filter)
        {
            routes.YearFilter = FilterPrefix.Year + filter[1];
            routes.QuarterFilter = FilterPrefix.Quarter + filter[2];
            routes.EmployeeFilter = FilterPrefix.Employee + filter[0];

        }
        public void ClearFilterSegments() => routes.ClearFilters();

        string def = SalesGridDTO.DefaultFilter;   
        public bool IsFilterByYear => routes.YearFilter != def;
        public bool IsFilterByQuarter => routes.QuarterFilter != def;
        public bool IsFilterByEmployee => routes.EmployeeFilter != def;
        public bool IsFilterByAmount => routes.AmountFilter != def;

        public bool IsSortByYear =>
            routes.SortField.EqualsNoCase(nameof(Sales.Year));
        public bool IsSortByQuarter =>
            routes.SortField.EqualsNoCase(nameof(Sales.Quarter));
        public bool IsSortByEmployee =>
            routes.SortField.EqualsNoCase(nameof(Employee));
        public bool IsSortByAmount =>
            routes.SortField.EqualsNoCase(nameof(Sales.Amount));
    }
}
