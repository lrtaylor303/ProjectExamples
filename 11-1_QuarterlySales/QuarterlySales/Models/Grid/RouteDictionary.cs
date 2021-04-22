using System;
using System.Collections.Generic;
using System.Linq;


namespace QuarterlySales.Models
{
    public static class FilterPrefix
    {
        public const string Year = "year=";
        public const string Quarter = "quarter-";
        public const string Employee = "employee-";
        public const string Amount = "amount-";
    }
    public class RouteDictionary : Dictionary<string, string>
    {
        public int PageNumber
        {
            get => Get(nameof(GridDTO.PageNumber)).ToInt();
            set => this[nameof(GridDTO.PageNumber)] = value.ToString();
        }

        public int PageSize
        {
            get => Get(nameof(GridDTO.PageSize)).ToInt();
            set => this[nameof(GridDTO.PageSize)] = value.ToString();
        }

        public string SortField
        {
            get => Get(nameof(GridDTO.SortField));
            set => this[nameof(GridDTO.SortField)] = value;
        }

        public string SortDirection
        {
            get => Get(nameof(GridDTO.SortDirection));
            set => this[nameof(GridDTO.SortDirection)] = value;
        }

        public void SetSortAndDirection(string fieldName, RouteDictionary current)
        {
            this[nameof(GridDTO.SortField)] = fieldName;

            if (current.SortField.EqualsNoCase(fieldName) &&
                current.SortDirection == "asc")
                this[nameof(GridDTO.SortDirection)] = "desc";
            else if(current.SortField.EqualsNoCase(fieldName) &&
                current.SortDirection == "desc")
                this[nameof(GridDTO.SortDirection)] = "asc";
        }

        public string YearFilter
        {
            get => Get(nameof(SalesGridDTO.Year))?.Replace(FilterPrefix.Year, "");
            set => this[nameof(SalesGridDTO.Year)] = value;
        }

        public string QuarterFilter
        {
            get => Get(nameof(SalesGridDTO.Quarter))?.Replace(FilterPrefix.Quarter, "");
            set => this[nameof(SalesGridDTO.Quarter)] = value;
        }

        public string EmployeeFilter
        {
            get => Get(nameof(SalesGridDTO.Employee))?.Replace(FilterPrefix.Employee, "");
            set => this[nameof(SalesGridDTO.Employee)] = value;
        }

        public string AmountFilter
        {
            get => Get(nameof(SalesGridDTO.Amount))?.Replace(FilterPrefix.Amount, "");
            set => this[nameof(SalesGridDTO.Amount)] = value;
        }


        public void ClearFilters() =>
            YearFilter = QuarterFilter = EmployeeFilter = AmountFilter = SalesGridDTO.DefaultFilter;

        private string Get(string key) => Keys.Contains(key) ? this[key] : null;

        public RouteDictionary Clone()
        {
            var clone = new RouteDictionary();
            foreach (var key in Keys)
            {
                clone.Add(key, this[key]);
            }
            return clone;
        }
    }
}
