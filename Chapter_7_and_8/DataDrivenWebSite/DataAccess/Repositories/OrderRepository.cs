using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repository;

namespace DataAccess.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {

        public OrderRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public IEnumerable<Order> GetAllOrders()
        {
            return this.GetDbSet<Order>();
        }

        public Order GetByOrderId(int orderId)
        {
            return this.GetDbSet<Order>().Find(orderId);
        }

        public void Create(Order order)
        {
            this.GetDbSet<Order>().Add(order);
        }

        public void Update(Order order)
        {
            this.SetEntityState(order, System.Data.EntityState.Modified);
        }

        public void Delete(int orderId)
        {
            var order = this.GetDbSet<Order>().Find(orderId);
            this.GetDbSet<Order>().Remove(order);
        }
    }
}
