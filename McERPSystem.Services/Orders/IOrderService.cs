using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McERPSystem.Services.Models;

namespace McERPSystem.Services.Orders
{
    
        public interface IOrderService
        {
            Task<List<Order>> GetAllOrdersAsync();
            Task<Order> GetOrderByIdAsync(int id);
            Task AddOrderAsync(Order order);
        }
    

}
