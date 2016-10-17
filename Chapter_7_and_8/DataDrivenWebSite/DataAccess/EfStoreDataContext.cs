using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace DataAccess
{
    public class EfStoreDataContext : StoreEntities, IUnitOfWork
    {
        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
