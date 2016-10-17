using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities;
using Repository;
using System.Transactions;

namespace DataDrivenWebSite.Commands
{
    public class CreateOrder
    {
        private readonly IOrderRepository orderRepository;

        public CreateOrder(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public virtual void Execute(Order order)
        {
            if (order == null) throw new ArgumentNullException("invalid order");

            try
            {
                orderRepository.Create(order);
                orderRepository.Save();
            }
            catch (Exception)
            {
                //LOG
                throw;
            }
        }
    }
}