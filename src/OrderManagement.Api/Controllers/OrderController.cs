using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Api.Models.Requests;
using OrderManagement.Api.Providers;
using OrderManagement.Infrastructure.Interfaces;

namespace OrderManagement.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ContextUserDataProvider _contextUserDataProvider;

        public OrderController(
            IUnitOfWork unitOfWork,
            ContextUserDataProvider contextUserDataProvider)
        {
            _unitOfWork = unitOfWork;
            _contextUserDataProvider = contextUserDataProvider;
        }

        [HttpPost]
        public async Task<IActionResult> PostOrder([FromBody] OrderModel model)
        {
            var product = await _unitOfWork.ProductRepository.GetById(model.ProductId);

            if (product == null)
            {
                return NotFound($"Product {model.ProductId} not found.");
            }

            var customerId = _contextUserDataProvider.GetCustomerId();
            var order = model.BuildOrder(customerId, product);

            await _unitOfWork.OrderRepository.Insert(order);
            await _unitOfWork.Commit();

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var customerId = _contextUserDataProvider.GetCustomerId();
            var orders = await _unitOfWork.OrderRepository.GetAll(e => e.CustomerId == customerId);

            return Ok(orders);
        }

        [HttpGet]
        [Route("{orderId}")]
        public async Task<IActionResult> GetOrderById([FromRoute] int orderId)
        {
            var customerId = _contextUserDataProvider.GetCustomerId();
            var orders = await _unitOfWork.OrderRepository.GetAll(e => e.CustomerId == customerId && e.Id == orderId);
            var order = orders.FirstOrDefault();

            return Ok(order);
        } 
    }
}
