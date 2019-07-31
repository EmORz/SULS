using System.Collections.Generic;
using Musaca.Data1.Models;

namespace Musaca.Services1
{
    public interface IOrderService
    {
        List<Order> GetAllCompleteOrderByCashierId(string userId);

        Order GetCurrentActiveOrderByCashierId(string userId);

        Order CoplitedOrder(string orderId, string userId);

        Order CreateOrder(Order order);

        bool AddProductToCurrentActiveOrder(string productId, string userId);
    }
}