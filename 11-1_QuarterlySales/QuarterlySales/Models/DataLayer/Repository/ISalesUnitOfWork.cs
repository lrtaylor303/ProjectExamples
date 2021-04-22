using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterlySales.Models
{
    public interface ISalesUnitOfWork
    {
        Repository<Sales> Sales { get; }
        Repository<Sales> Year { get; }
        Repository<Sales> Quarter { get; }
        Repository<Employee> Employee { get; }
        Repository<Sales> Amount { get; }

        void Save();
    }
}
