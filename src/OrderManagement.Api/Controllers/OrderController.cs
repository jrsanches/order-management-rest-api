using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Api.Models.Requests;
using OrderManagement.Infrastructure.Interfaces;
using System.Security.Claims;

namespace OrderManagement.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderController(
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public async Task<IActionResult> PostOrder([FromBody] OrderModel model)
        {
            var product = await _unitOfWork.ProductRepository.GetById(model.ProductId);

            if (product == null)
            {
                return NotFound($"Product {model.ProductId} not found.");
            }

            var customerId = GetCustomerId();
            var order = model.BuildOrder(customerId, product, model.QuantityOfProducts);

            await _unitOfWork.OrderRepository.Insert(order);
            await _unitOfWork.Commit();

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var customerId = GetCustomerId();
            var orders = await _unitOfWork.OrderRepository.GetAll(e => e.CustomerId == customerId);

            return Ok(orders);
        }

        [HttpGet]
        [Route("{orderId}")]
        public async Task<IActionResult> GetOrderById([FromRoute] int orderId)
        {
            var order = await _unitOfWork.OrderRepository.GetById(orderId);

            return Ok(order);
        }
        private int GetCustomerId()
        {
            return Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.NameIdentifier).Value);
        }
    }
}
