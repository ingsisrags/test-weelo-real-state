using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Product.DTOs.Realstate.Input;
using Product.DTOs.Realstate.Output;
using Product.Service.Interfaces;

namespace Product.Api.Controllers
{
    [Route("Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        /// <summary>
        /// Post method for create building, return object with Id and name
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<PropertyOutput> CreateBuilding(CreatePropertyInput input)
        {
            var output = await _productService.CreatePropertyBuilding(input);
            return output;
        }

    }
}
