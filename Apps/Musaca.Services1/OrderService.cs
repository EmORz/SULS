using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Musaca.Data1;
using Musaca.Data1.Models;

namespace Musaca.Services1
{
    public class OrderService : IOrderService
    {
        private readonly MusacaDbContext db;

        public OrderService(MusacaDbContext db)
        {
            this.db = db;
        }


        public List<Order> GetAllCompleteOrderByCashierId(string userId)
        {
            var orders = this.db.Orders
                .Include(order => order.Products)
                .ThenInclude( x => x.Product)
                .Include( cashier => cashier.Cashier)
                .Where(x => x.CashierId == userId && x.Status == StatusOrder.Completed).ToList();

            return orders;
        }

        public Order GetCurrentActiveOrderByCashierId(string userId)
        {
            var orderByCashierId = this.db.Orders
                .Include(order => order.Products)
                .ThenInclude(x => x.Product)
                .Include(cashier => cashier.Cashier)
                .SingleOrDefault(x => x.CashierId == userId && x.Status == StatusOrder.Active);

            return orderByCashierId;
        }

        public Order CoplitedOrder(string orderId, string userId)
        {
            var orderFromDb = this.db.Orders.SingleOrDefault(x => x.Id == orderId);

            orderFromDb.Status = StatusOrder.Completed;
            orderFromDb.IssuedOn = DateTime.UtcNow;

            this.db.Orders.Add(orderFromDb);
            this.db.SaveChanges();

            this.CreateOrder(new Order(){CashierId = userId});

            return orderFromDb;


        }

        public Order CreateOrder(Order order)
        {
            this.db.Orders.Add(order);
            this.db.SaveChanges();
            return order;
        }

        public bool AddProductToCurrentActiveOrder(string produtcId, string userId)
        {
            var product = this.db.Products.SingleOrDefault(x => x.Id == produtcId);

            var order = this.GetCurrentActiveOrderByCashierId(userId);

            order.Products.Add(new OrderProduct()
            {
                Product = product
            });

            this.db.Orders.Add(order);
            this.db.SaveChanges();

            return true;



        }
    }
}