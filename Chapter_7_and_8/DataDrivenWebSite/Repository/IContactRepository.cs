using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repository
{
    public interface IContactRepository : IDisposable
    {
        IEnumerable<Contact> GetAllContacts();
        Contact GetByContactId(int contactId);
        void Create(Contact contact);
        void Update(Contact contact);
        void Delete(int contactId);
        void Save();
    }
}
