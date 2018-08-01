using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        public OrderRepository(DataContext context){
            _context = context;
        }
        public async Task<bool> AddOrder(Order order)
        {
            order.OrderedBy = await _context.Users.FirstOrDefaultAsync(x => x.Id == order.OrderedBy.Id);

            await _context.Orders.AddAsync(order);
            int result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteOrder(Order order)
        {
            _context.Orders.Remove(order);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> EditOrder(Order order)
        {
            var orderToChange = await _context.Orders.FirstAsync(x => x.Id == order.Id);
            _context.Entry(orderToChange).CurrentValues.SetValues(order);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _context.Orders.Include(x => x.OrderedBy).ToListAsync();
        }

        public Task<Order> GetOrder(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}