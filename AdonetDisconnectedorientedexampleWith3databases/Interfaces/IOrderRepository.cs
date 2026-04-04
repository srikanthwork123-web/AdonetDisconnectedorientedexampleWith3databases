using AdonetDisconnectedorientedexampleWith3databases.Models;

namespace AdonetDisconnectedorientedexampleWith3databases.Interfaces
{
    public interface IOrderRepository
    {//in repository we used model classes.
        Task<bool> AddOrder(Order Objord);
        Task<bool> UpdateOrder(Order Objord);
        Task<bool> DeleteOrder(int OrderId);
        Task<List<Order>> GetallOrders();
        Task<Order> GetOrderById(int Id);
    }
}
