using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterlySales.Models
{
    public class SalesUnitOfWork : ISalesUnitOfWork
    {
        private SalesContext context { get; set; }
        public SalesUnitOfWork(SalesContext ctx) => context = ctx;

        private Repository<Sales> saleData;
        public Repository<Sales> Sales
        {
            get
            {
                if (saleData == null)
                    saleData = new Repository<Sales>(context);
                return saleData;
            }
        }

        private Repository<Sales> yearData;
        public Repository<Sales> Year
        {
            get
            {
                if (yearData == null)
                    yearData = new Repository<Sales>(context);
                return yearData;
            }
        }

        private Repository<Sales> quarterData;
        public Repository<Sales> Quarter
        {
            get
            {
                if (quarterData == null)
                    quarterData = new Repository<Sales>(context);
                return quarterData;
            }
        }

        private Repository<Employee> employeeData;
        public Repository<Employee> Employee
        {
            get
            {
                if (employeeData == null)
                    employeeData = new Repository<Employee>(context);
                return employeeData;
            }
        }

        private Repository<Sales> amountData;
        public Repository<Sales> Amount
        {
            get
            {
                if (amountData == null)
                    amountData = new Repository<Sales>(context);
                return amountData;
            }
        }

        public void Save() => context.SaveChanges();

    }
}
