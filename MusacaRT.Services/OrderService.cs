using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MusacaRT.Data;
using MusacaRT.Models;
using MusacaRT.Models.Enums;

namespace MusacaRT.Services
{
    public class OrderService : IOrderService
    {
        private readonly MusacaDbContext db;

        public OrderService(MusacaDbContext db)
        {
            this.db = db;
        }

        public bool AddProductToCurrentActiveOrder(string productId, string userId)
        {
            var currentProduct = this.db.Products.FirstOrDefault(p => p.Id == productId);
            var currentActiveOrder = this.GetCurrentActiveOrderByCashierId(userId);

            currentActiveOrder.Products.Add(new OrderProduct()
            {
                Product = currentProduct
            });
            this.db.Update(currentActiveOrder);
            this.db.SaveChanges();

            return true;
        }

        public Order CreateOrder(Order order)
        {
            
            this.db.Orders.Add(order);
            this.db.SaveChanges();
            return order;
        }

        public Order CompliteOrderById(string orderId, string userId)
        {
            var compliteOrderById = this.db.Orders.FirstOrDefault(o => o.Id == orderId);

            compliteOrderById.IssuedOn = DateTime.UtcNow;
            compliteOrderById.Status = OrderStatus.Completed;

            this.db.Update(compliteOrderById);

            this.db.SaveChanges();

            this.CreateOrder(new Order(){CashierId = userId});

            return compliteOrderById;

        }

        public List<Order> GetAllComplitedOrderByCashierId(string userId)
        {
            var allComplitedOrder = this.db.Orders
                .Include(order => order.Products)
                .ThenInclude(orderProduct => orderProduct.Product)
                .Include(order => order.Cashier)
                .Where(x => x.CashierId == userId)
                .Where(x => x.Status == OrderStatus.Completed)
                .ToList();
            return allComplitedOrder;

        }

        public Order GetCurrentActiveOrderByCashierId(string userId)
        {
            var complitedOrderByCahierId = this.db.Orders
                .Include(order => order.Products)
                .ThenInclude(orderProduct => orderProduct.Product)
                .Include(order => order.Cashier)
                .FirstOrDefault(x => x.CashierId == userId && x.Status == OrderStatus.Active);
            return complitedOrderByCahierId;
        }
    }
}