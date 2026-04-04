using AdonetDisconnectedorientedexampleWith3databases.Dto;

namespace AdonetDisconnectedorientedexampleWith3databases.Interfaces
{
    public interface IOrderService
    {//in services we used Dto classes.
        Task<bool> AddOrder(OrderDto Objord);
        Task<bool> UpdateOrder(OrderDto Objord);
        Task<bool> DeleteOrder(int OrderId);
        Task<List<OrderDto>> GetallOrders();
        Task<OrderDto> GetOrderById(int Id);
    }
}

