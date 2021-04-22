﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace QuarterlySales.Models
{
    public class QueryOptions<T>
    {
        public Expression<Func<T, Object>> OrderBy { get; set; }
        public string OrderByDirection { get; set; } = "asc";  
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public WhereClauses<T> WhereClauses { get; set; }
        public Expression<Func<T, bool>> Where
        {
            set
            {
                if (WhereClauses == null)
                {
                    WhereClauses = new WhereClauses<T>();
                }
                WhereClauses.Add(value);
            }
        }

        private string[] includes;


        public string[] GetIncludes() => includes ?? new string[0];

        public bool HasWhere => WhereClauses != null;
        public bool HasOrderBy => OrderBy != null;
    }

    public class WhereClauses<T> : List<Expression<Func<T, bool>>> { }
}
