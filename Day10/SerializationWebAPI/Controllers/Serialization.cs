using Microsoft.AspNetCore.Mvc;
using SerializationWebAPI.Entities;
using SerializationWebAPI.Services;
using SerializationWebAPI.Repositories;

namespace SerializationWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SerializationController : ControllerBase
    {
        private readonly ILogger<SerializationController> _logger;
        private readonly IProductService _productService;

        public SerializationController(
            ILogger<SerializationController> logger,
            IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productService.GetAllProducts();
        }
    }
}
