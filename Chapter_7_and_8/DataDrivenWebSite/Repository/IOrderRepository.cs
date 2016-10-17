using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repository
{
    public interface IOrderRepository : IDisposable
    {
        IEnumerable<Order> GetAllOrders();
        Order GetByOrderId(int orderId);
        void Create(Order order);
        void Update(Order order);
        void Delete(int orderId);
        void Save();
    } 

}
