using AdonetDisconnectedorientedexampleWith3databases.Dto;
using AdonetDisconnectedorientedexampleWith3databases.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdonetDisconnectedorientedexampleWith3databases.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]//post is used to insert the data into the database and it is used to create a new resource/record in the database
        [Route("AddOrder")]
        public async Task<IActionResult> Post(OrderDto objorder)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var ord = await _orderService.AddOrder(objorder);
                    return StatusCode(StatusCodes.Status200OK, ord);

                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpPut]//put is used to update the data in the database and it is used to update an existing resource/record in the database
        [Route("UpdateOrder")]
        public async Task<IActionResult> Updateorder(OrderDto objorder)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var ord = await _orderService.UpdateOrder(objorder);
                    return StatusCode(StatusCodes.Status200OK, ord);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");

            }

        }
        [HttpDelete]
        [Route("DeleteOrder")]//delete is used to delete the data from the database and it is used to delete an existing resource/record from the database
        public async Task<IActionResult> Deleteorder(int OrderId)
        {

            if (OrderId < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad Request");
            }
            try
            {
                var order = await _orderService.DeleteOrder(OrderId);
                if (order == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Order Not Found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, "Order Deleted Successfully");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet]
        [Route("GetOrder")]//get is used to retrieve the data from the database and it is used to retrieve an existing resource/record from the database
        public async Task<IActionResult> GetOrder()
        {
            var order = await _orderService.GetallOrders();
            if (order == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Order Details Not Fount");
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, order);
            }
        }
        [HttpGet]
        [Route("GetOrdersbyId")]//get is used to retrieve the data from the database and it is used to retrieve an existing resource/record from the database by using the id
        public async Task<IActionResult> GetorderbyId(int OrderId)
        {
            if (OrderId < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad Request");
            }
            try
            {
                var res = await _orderService.GetOrderById(OrderId);
                if (res == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Order Not Found");

                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, res);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }

        }
    }
}
