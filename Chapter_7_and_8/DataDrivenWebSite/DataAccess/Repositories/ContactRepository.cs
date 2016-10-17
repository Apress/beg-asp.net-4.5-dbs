using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repository;

namespace DataAccess.Repositories
{
    public class ContactRepository : IContactRepository, IDisposable
    {
        private StoreEntities context;
        private bool disposed = false;

        public ContactRepository(StoreEntities context)
        {
            this.context = context;
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return context.Contacts.AsEnumerable();
        }

        public Contact GetByContactId(int contactId)
        {
            return context.Contacts.Find(contactId);
        }

        public void Create(Contact contact)
        {
            context.Contacts.Add(contact);
        }

        public void Update(Contact contact)
        {
            context.Entry(contact).State = System.Data.EntityState.Modified;
        }

        public void Delete(int contactId)
        {
            var contact = context.Contacts.Find(contactId);
            context.Contacts.Remove(contact);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        } 
    }
}
