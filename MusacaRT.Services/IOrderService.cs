using System.Collections.Generic;
using MusacaRT.Models;

namespace MusacaRT.Services
{
    public interface IOrderService
    {
        bool AddProductToCurrentActiveOrder(string userId, string orderId);
        Order CreateOrder(Order order);

        Order CompliteOrderById(string orderId, string userd);

        List<Order> GetAllComplitedOrderByCashierId(string userId);

        Order GetCurrentActiveOrderByCashierId(string userId);
    }
}