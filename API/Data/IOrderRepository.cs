using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Data
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrders();
        Task<Order> GetOrder(int id);
        Task<bool> AddOrder(Order order);
        Task<bool> EditOrder(Order order, Order orderToChange);
        Task<bool> DeleteOrder(Order order);
        Task<List<OrderStatus>> GetAllStatuses();
    }
}