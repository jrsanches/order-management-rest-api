using Microsoft.AspNetCore.Mvc;
using OrderManagement.Infrastructure.Interfaces;

namespace OrderManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _unitOfWork.ProductRepository.GetAll();

            return Ok(products);
        }

        /// <summary>
        /// Get a product by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{productId}")]
        public async Task<IActionResult> GetProductById([FromRoute]int productId)
        {
            var product = await _unitOfWork.ProductRepository.GetById(productId);

            return Ok(product);
        }
    }
}
