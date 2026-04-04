using AdonetDisconnectedorientedexampleWith3databases.Dto;
using AdonetDisconnectedorientedexampleWith3databases.Interfaces;
using AdonetDisconnectedorientedexampleWith3databases.Models;

namespace AdonetDisconnectedorientedexampleWith3databases.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        //To implement dependency injection in the service class,
        //we need to inject the repository interface in the constructor of the service class
        //and assign it to the private readonly field of the repository interface type.
        //This way we can use the repository methods in the service class to perform the CRUD operations on the database.
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> AddOrder(OrderDto Objord)
        {
            Order objorder = new Order();
            objorder.OrderLocation = Objord.OrderLocation;
            objorder.OrderName = Objord.OrderName;
            var res = await _orderRepository.AddOrder(objorder);
            return res;
        }

        public async Task<bool> DeleteOrder(int OrderId)
        {
            await _orderRepository.DeleteOrder(OrderId);
            return true;
        }

        public async Task<List<OrderDto>> GetallOrders()
        {
            List<OrderDto> ordlist = new List<OrderDto>();
            var getorder = await _orderRepository.GetallOrders();
            foreach (var order in getorder)
            {
                OrderDto ordobj = new OrderDto();
                ordobj.OrderId = order.OrderId;
                ordobj.OrderName = order.OrderName;
                ordobj.OrderLocation = order.OrderLocation;
                ordlist.Add(ordobj);


            }
            return ordlist;
        }

        public async Task<OrderDto> GetOrderById(int Id)
        {
            var res = await _orderRepository.GetOrderById(Id);
            OrderDto objorder = new OrderDto();
            objorder.OrderId = res.OrderId;
            objorder.OrderName = res.OrderName;
            objorder.OrderLocation = res.OrderLocation;
            return objorder;
        }

        public async Task<bool> UpdateOrder(OrderDto Objord)
        {

            Order order = new Order();
            order.OrderId = Objord.OrderId;
            order.OrderName = Objord.OrderName;
            order.OrderLocation = Objord.OrderLocation;
            await _orderRepository.UpdateOrder(order);
            return true;
        }
    }
}
