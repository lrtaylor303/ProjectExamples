using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Models
{
    public interface IContactUnitOfWork
    {
        public IRepository<Category> Categories { get; }
        public IRepository<Contact> Contacts { get; }

        public void Save();
    }
}
